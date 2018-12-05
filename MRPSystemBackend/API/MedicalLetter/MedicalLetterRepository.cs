using Dapper;
using Microsoft.Extensions.Configuration;
using MRPSystemBackend.Common;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.MedicalLetter
{
    public class MedicalLetterRepository : IMedicalLetterRepository
    {
        IConfiguration configuration;

        public MedicalLetterRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("OracleConStr").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }


        public int CreateMedicalLetter(MedicalLetter medicalLetter)
        {
            int Id = 0;
            var conn = this.GetConnection();

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var transaction = conn.BeginTransaction())
            {
                try
                {



                    var p = new DynamicParameters();
                    p.Add("IPAssureId", medicalLetter.AssureId);
                    p.Add("IPMainId", medicalLetter.MainId);
                    p.Add("IPHospitalId", medicalLetter.HospitalId);
                    p.Add("IPLetterDate", medicalLetter.LetterDate);
                    p.Add("IPLetterType", medicalLetter.LetterType);
                    p.Add("IPSignPersonUserCode", medicalLetter.SignPersonUserCode);
                    p.Add("IPGeneratedUser", medicalLetter.GeneratedUser);
                    p.Add("IPShouldCommit", 1);
                    p.Add("OPMedicalLetterId", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 50);

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Execute("MRPSInsertMedicalLetter", p, commandType: CommandType.StoredProcedure);
                        Id = p.Get<int>("OPMedicalLetterId");
                    }


                    for (int i = 0; i < medicalLetter.SelectedMedicalTests.Count; i++)
                    {
                        CreateMedicalLetterTestWithTransaction(Id, medicalLetter.SelectedMedicalTests[i], conn);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Id;
        }
        //public int CreateMedicalLetterWithTransaction(MedicalLetter medicalLetter, IDbConnection connection)
        //{
        //    int Id = 0;
        //    try
        //    {
        //        var conn = connection;
        //        if (conn.State == ConnectionState.Closed)
        //        {
        //            conn.Open();
        //        }
        //        var p = new DynamicParameters();
        //        p.Add("IPAssureId", medicalLetter.AssureId);
        //        p.Add("IPMainId", medicalLetter.MainId);
        //        p.Add("IPHospitalId", medicalLetter.HospitalId);
        //        p.Add("IPLetterDate", medicalLetter.LetterDate);
        //        p.Add("IPLetterType", medicalLetter.LetterType);
        //        p.Add("IPSignPersonUserCode", medicalLetter.SignPersonUserCode);
        //        p.Add("IPGeneratedUser", medicalLetter.GeneratedUser);
        //        p.Add("IPShouldCommit", 0);
        //        p.Add("OPMedicalLetterId", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);

        //        if (conn.State == ConnectionState.Open)
        //        {
        //            conn.Execute("MRPSInsertMedicalLetter", p, commandType: CommandType.StoredProcedure);
        //            Id = p.Get<int>("OPMedicalLetterId");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Id;
        //}

        public void CreateMedicalLetterTestWithTransaction(int medicalLetterId, int testId, IDbConnection connection)
        {
            try
            {
                var conn = connection;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var p = new DynamicParameters();
                p.Add("IPMedicalLetterId", medicalLetterId);
                p.Add("IPTestId", testId);
                p.Add("IPShouldCommit", 0);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Execute("MRPSInsertMedicalLetterTest", p, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public MedicalLetter GetMedicalLetterById(int letterId)
        {
            MedicalLetter result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("IPMedicalLetterId", OracleDbType.Int32, ParameterDirection.Input, letterId);
                dyParam.Add("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetMedicalLetterByID";
                    result = SqlMapper.QueryFirst<MedicalLetter>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int UpdateMedicalLetter(MedicalLetter medicalLetter)
        {
            int result = 0;
            var conn = this.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var transaction = conn.BeginTransaction())
            {
                try
                {

                    var p = new DynamicParameters();
                    p.Add("IPSeqId", medicalLetter.SeqId);
                    p.Add("IPAssureId", medicalLetter.AssureId);
                    p.Add("IPMainId", medicalLetter.MainId);
                    p.Add("IPHospitalId", medicalLetter.HospitalId);
                    p.Add("IPLetterDate", medicalLetter.LetterDate);
                    p.Add("IPLetterType", medicalLetter.LetterType);
                    p.Add("IPSignPersonUserCode", medicalLetter.SignPersonUserCode);

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Execute("MRPSUpdateMedicalLetter", p, commandType: CommandType.StoredProcedure);
                        result = medicalLetter.SeqId;
                    }

                    DeleteMedicalLetterTest(medicalLetter.SeqId, conn);

                    for (int i = 0; i < medicalLetter.SelectedMedicalTests.Count; i++)
                    {
                        CreateMedicalLetterTestWithTransaction(medicalLetter.SeqId, medicalLetter.SelectedMedicalTests[i], conn);
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public void DeleteMedicalLetterTest(int medicalLetterId, IDbConnection connection)
        {

            var conn = connection;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            try
            {
                var p = new DynamicParameters();
                p.Add("IPMedicalLetterId", medicalLetterId);
                p.Add("IPShouldCommit", 1);

                if (conn.State == ConnectionState.Open)
                {
                    conn.Execute("MRPSDeleteMedicalLetterTest", p, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
