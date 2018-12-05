using Dapper;
using Microsoft.Extensions.Configuration;
using MRPSystemBackend.Common;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.MedicalTest
{
    public class MedicalTestRepository : IMedicalTestRepository
    {
        IConfiguration configuration;

        public MedicalTestRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("OracleConStr").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }

        public IEnumerable<MedicalTest> GetMedicalTests()
        {
            IEnumerable<MedicalTest> result = null;
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
                    var query = "MRPSGetAllMedicalTests";
                    result = SqlMapper.Query<MedicalTest>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
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
