using Dapper;
using Microsoft.Extensions.Configuration;
using MRPSystemBackend.API.Common.Models;
using MRPSystemBackend.Common;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Common
{
    public class CommonRepository : ICommonRepository
    {
        IConfiguration configuration;


        public CommonRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("OracleConStr").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }



        public IEnumerable<Nationality> GetAllNationalities()
        {
            IEnumerable<Nationality> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("NationalityCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "GetAllNationalities";

                    result = SqlMapper.Query<Nationality>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Nationality GetNationalityById(int nationalityID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bank> GetAllBanks()
        {
            IEnumerable<Bank> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetAllBanks";

                    result = SqlMapper.Query<Bank>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public IEnumerable<BankBranch> GetAllBankBranches()
        {
            IEnumerable<BankBranch> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetAllBankBranches";

                    result = SqlMapper.Query<BankBranch>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public IEnumerable<BankBranch> GetBankBranchesOfBank(int bankId)
        {
            IEnumerable<BankBranch> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("IPBankId", OracleDbType.Int32, ParameterDirection.Input, bankId);
                dyParam.Add("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetBankBranchesOfBank";

                    result = SqlMapper.Query<BankBranch>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public IEnumerable<Broker> GetAllBrokers()
        {
            IEnumerable<Broker> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetAllBrokers";

                    result = SqlMapper.Query<Broker>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public IEnumerable<BusinessChannel> GetAllBusinessChannels()
        {
            IEnumerable<BusinessChannel> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetAllBusinessChannels";

                    result = SqlMapper.Query<BusinessChannel>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public IEnumerable<ModeOfProposal> GetAllModeOfProposals()
        {
            IEnumerable<ModeOfProposal> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetAllModeOfProposals";

                    result = SqlMapper.Query<ModeOfProposal>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public IEnumerable<MRPUser> GetAllMRPUsers()
        {
            IEnumerable<MRPUser> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetAllMRPUsers";

                    result = SqlMapper.Query<MRPUser>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public IEnumerable<UserPendingJob> GetPendingJobsOfUsers()
        {
            IEnumerable<UserPendingJob> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetPendingJobsOfUsers";

                    result = SqlMapper.Query<UserPendingJob>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
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
