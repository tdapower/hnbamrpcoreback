using Dapper;
using Microsoft.Extensions.Configuration;
using MRPSystemBackend.Common;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.WorkflowJob
{
    public class WorkflowJobRepository : IWorkflowJobRepository
    {
        IConfiguration configuration;

        public WorkflowJobRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("OracleConStr").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }



        public string CreateWorkflowJob(WorkflowJob workflowJob)
        {
            string newJobNo = "";
            try
            {

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var p = new DynamicParameters();
                p.Add("IPProposalNo", workflowJob.ProposalNo);
                p.Add("IPNIC1", workflowJob.LifeAssure1NIC);
                p.Add("IPNIC2", workflowJob.LifeAssure2NIC);
                p.Add("IPBankCode", workflowJob.BankCode);
                p.Add("IPAssignedUserCode", workflowJob.AssignedUserCode);
                p.Add("IPBrokerCode", workflowJob.BrokerCode);
                p.Add("IPIsFastTrack", workflowJob.IsFastTrack);
                p.Add("IPProposalModeId", workflowJob.ProposalModeId);
                p.Add("IPWorkflowType", workflowJob.WorkflowType);
                p.Add("IPBusinessChnlId", workflowJob.BusinessChannelId);
                p.Add("IPIsFreeCvrLimitPrpsl", workflowJob.IsFreeCoverLimitProposal);

                p.Add("IPBankId", workflowJob.BankId);
                p.Add("IPBankBranchId", workflowJob.BankBranchId);

                p.Add("IPCreatedUserCode", workflowJob.CreatedUserCode);

                p.Add("IPShouldCommit", 1);

                p.Add("OPJobNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);

                if (conn.State == ConnectionState.Open)
                {
                    conn.Execute("MRPSCreateWorkflowJob", p, commandType: CommandType.StoredProcedure);
                    newJobNo = p.Get<string>("OPJobNo");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return newJobNo;
        }

        public string CreateWorkflowJobWithTransaction(WorkflowJob workflowJob, IDbConnection connection)
        {
            string newJobNo = "";
            try
            {

                var conn = connection;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var p = new DynamicParameters();
                p.Add("IPProposalNo", workflowJob.ProposalNo);
                p.Add("IPNIC1", workflowJob.LifeAssure1NIC);
                p.Add("IPNIC2", workflowJob.LifeAssure2NIC);
                p.Add("IPBankCode", workflowJob.BankCode);
                p.Add("IPAssignedUserCode", workflowJob.AssignedUserCode);
                p.Add("IPBrokerCode", workflowJob.BrokerCode);
                p.Add("IPIsFastTrack", workflowJob.IsFastTrack);
                p.Add("IPProposalModeId", workflowJob.ProposalModeId);
                p.Add("IPWorkflowType", workflowJob.WorkflowType);
                p.Add("IPBusinessChnlId", workflowJob.BusinessChannelId);
                p.Add("IPIsFreeCvrLimitPrpsl", workflowJob.IsFreeCoverLimitProposal);

                p.Add("IPBankId", workflowJob.BankId);
                p.Add("IPBankBranchId", workflowJob.BankBranchId);

                p.Add("IPCreatedUserCode", workflowJob.CreatedUserCode);
                p.Add("IPShouldCommit", 0);
                p.Add("OPJobNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);

                if (conn.State == ConnectionState.Open)
                {
                    conn.Execute("MRPSCreateWorkflowJob", p, commandType: CommandType.StoredProcedure);
                    newJobNo = p.Get<string>("OPJobNo");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return newJobNo;
        }

        public IEnumerable<WorkflowJob> SearchWorkflowJob(SearchWorkflowJob searchWorkflowJob)
        {
            IEnumerable<WorkflowJob> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("IPJobNo", OracleDbType.Varchar2, ParameterDirection.Input, searchWorkflowJob.JobNo);
                dyParam.Add("IPProposalNo", OracleDbType.Varchar2, ParameterDirection.Input, searchWorkflowJob.ProposalNo);
                dyParam.Add("IPNIC1", OracleDbType.Varchar2, ParameterDirection.Input, searchWorkflowJob.LifeAssure1NIC);
                dyParam.Add("IPNIC2", OracleDbType.Varchar2, ParameterDirection.Input, searchWorkflowJob.LifeAssure2NIC);
                dyParam.Add("IPAssignedUserCode", OracleDbType.Varchar2, ParameterDirection.Input, searchWorkflowJob.AssignedUserCode);



                dyParam.Add("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSSearchWorkflowJobs";

                    result = SqlMapper.Query<WorkflowJob>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public WorkflowJob GetWorkflowjobByJobNo(string jobNo)
        {

            WorkflowJob result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("IPJobNo", OracleDbType.Varchar2, ParameterDirection.Input, jobNo);
                dyParam.Add("OPAssureCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetWorkflowJobByJobNo";

                    result = SqlMapper.QueryFirst<WorkflowJob>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;


        }

        public int UpdateWorkflowJob(WorkflowJob workflowJob)
        {
            int result = 0;
            try
            {
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var p = new DynamicParameters();

                p.Add("IPJobNo", workflowJob.JobNo);
                p.Add("IPProposalNo", workflowJob.ProposalNo);
                p.Add("IPNIC1", workflowJob.LifeAssure1NIC);
                p.Add("IPNIC2", workflowJob.LifeAssure2NIC);
                p.Add("IPBankCode", workflowJob.BankCode);
                p.Add("IPAssignedUserCode", workflowJob.AssignedUserCode);
                p.Add("IPBrokerCode", workflowJob.BrokerCode);
                p.Add("IPIsFastTrack", workflowJob.IsFastTrack);
                p.Add("IPProposalModeId", workflowJob.ProposalModeId);
                p.Add("IPWorkflowType", workflowJob.WorkflowType);
                p.Add("IPBusinessChnlId", workflowJob.BusinessChannelId);
                p.Add("IPIsFreeCvrLimitPrpsl", workflowJob.IsFreeCoverLimitProposal);
                p.Add("IPBankId", workflowJob.BankId);
                p.Add("IPBankBranchId", workflowJob.BankBranchId);
                p.Add("IPShouldCommit", 1);
                
                if (conn.State == ConnectionState.Open)
                {
                    conn.Execute("MRPSUpdateWorkflowJob", p, commandType: CommandType.StoredProcedure);

                    result = 1;
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
