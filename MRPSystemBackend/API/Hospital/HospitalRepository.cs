using Dapper;
using Microsoft.Extensions.Configuration;
using MRPSystemBackend.Common;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Hospital
{
    public class HospitalRepository : IHospitalRepository
    {
        IConfiguration configuration;

        public HospitalRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("OracleConStr").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
        public int AddHospital(Hospital hospital)
        {
            int seqId = 0;

            try
            {
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var parameters = new DynamicParameters();
                parameters.Add("IPHospitalCode", hospital.HospitalCode);
                parameters.Add("IPName", hospital.Name);
                parameters.Add("IPAddress", hospital.Address);
                parameters.Add("IPCity", hospital.City);
                parameters.Add("IPTelephoneNo", hospital.TelephoneNo);
                parameters.Add("IPFax", hospital.Fax);
                parameters.Add("IPEMail", hospital.EMail);
                parameters.Add("IPRemarks", hospital.Remarks);
                parameters.Add("IPRegisterUserCode", hospital.RegisterUserCode);
                parameters.Add("IPShouldCommit", 1);

                parameters.Add("OPSeqId", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 50);

                if (conn.State == ConnectionState.Open)
                {
                    conn.ExecuteScalar<int>("MRPSInsertHospital", parameters, commandType: CommandType.StoredProcedure);
                    seqId = parameters.Get<int>("OPSeqId");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return seqId;
        }

        public int AddHospitalWithTransaction(Hospital hospital, IDbConnection connection)
        {
            int seqId = 0;

            try
            {
                var conn = connection;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var parameters = new DynamicParameters();
                parameters.Add("IPHospitalCode", hospital.HospitalCode);
                parameters.Add("IPName", hospital.Name);
                parameters.Add("IPAddress", hospital.Address);
                parameters.Add("IPCity", hospital.City);
                parameters.Add("IPTelephoneNo", hospital.TelephoneNo);
                parameters.Add("IPFax", hospital.Fax);
                parameters.Add("IPEMail", hospital.EMail);
                parameters.Add("IPRemarks", hospital.Remarks);
                parameters.Add("IPRegisterUserCode", hospital.RegisterUserCode);
                parameters.Add("IPShouldCommit", 1);

                parameters.Add("OPSeqId", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 50);

                if (conn.State == ConnectionState.Open)
                {
                    conn.ExecuteScalar<int>("MRPSInsertHospital", parameters, commandType: CommandType.StoredProcedure);
                    seqId = parameters.Get<int>("OPSeqId");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return seqId;
        }

        public Hospital GetHospitalById(int hospitalId)
        {
            Hospital result = null;
            
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("IPHospitalId", OracleDbType.Int32, ParameterDirection.Input, hospitalId);
                dyParam.Add("OPResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);
                    

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetHospitalByID";

                    result = SqlMapper.QueryFirst<Hospital>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;

        }

        public IEnumerable<Hospital> SearchHospitals(SearchHospital searchHospital)
        {
            IEnumerable<Hospital> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("IPHospitalCode", OracleDbType.Varchar2, ParameterDirection.Input, searchHospital.HospitalCode);
                dyParam.Add("IPName", OracleDbType.Varchar2, ParameterDirection.Input, searchHospital.Name);
                dyParam.Add("IPAddress", OracleDbType.Varchar2, ParameterDirection.Input, searchHospital.Address);


                dyParam.Add("OPResult", OracleDbType.RefCursor, ParameterDirection.Output);

                

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSSearchHospitals";

                    result = SqlMapper.Query<Hospital>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public int UpdateHospital(Hospital hospital)
        {
            int result = 0;
            try
            {
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var parameters = new DynamicParameters();
                parameters.Add("IPSeqId", hospital.SeqId);
                parameters.Add("IPHospitalCode", hospital.HospitalCode);
                parameters.Add("IPName", hospital.Name);
                parameters.Add("IPAddress", hospital.Address);
                parameters.Add("IPCity", hospital.City);
                parameters.Add("IPTelephoneNo", hospital.TelephoneNo);
                parameters.Add("IPFax", hospital.Fax);
                parameters.Add("IPEMail", hospital.EMail);
                parameters.Add("IPRemarks", hospital.Remarks);
                
                if (conn.State == ConnectionState.Open)
                {
                    conn.Execute("MRPSUpdateHospital", parameters, commandType: CommandType.StoredProcedure);

                    result = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public IEnumerable<Hospital> GetHospitals()
        {
            IEnumerable<Hospital> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                
                dyParam.Add("OPResult", OracleDbType.RefCursor, ParameterDirection.Output);
                
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetHospitals";
                    result = SqlMapper.Query<Hospital>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

    
    }
}
