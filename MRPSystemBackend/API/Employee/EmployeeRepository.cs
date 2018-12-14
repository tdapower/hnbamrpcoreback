using Dapper;
using Microsoft.Extensions.Configuration;
using MRPSystemBackend.Common;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        IConfiguration configuration;

        public EmployeeRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("OracleConStr").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }


        public int AddEmployee(Employee emp)
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
                parameters.Add("IPName", emp.Name);
                parameters.Add("IPDepartment", emp.Department);
                parameters.Add("OPEmployeeID", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 50);

                conn.ExecuteScalar<int>("TDAInsertEmployeeTest", parameters, commandType: CommandType.StoredProcedure);
                seqId = parameters.Get<int>("OPEmployeeID");
            }
            catch (Exception e)
            {
                throw e;
            }
            return seqId;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            IEnumerable<Employee> result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                
                var query = "TDAGetAllEmplloyee";
                result = SqlMapper.Query<Employee>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
