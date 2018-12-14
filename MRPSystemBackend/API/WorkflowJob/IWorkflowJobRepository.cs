using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.WorkflowJob
{
    public interface IWorkflowJobRepository
    {

        IEnumerable<WorkflowJob> SearchWorkflowJob(SearchWorkflowJob searchWorkflowJob);
        IEnumerable<WorkflowJob> GetUnassWorkflowJobs( );
        string CreateWorkflowJob(WorkflowJob workflowJob);

        string CreateWorkflowJobWithTransaction(WorkflowJob workflowJob, IDbConnection connection);


        WorkflowJob GetWorkflowjobByJobNo(string jobNo);
        int UpdateWorkflowJob(WorkflowJob workflowJob);

    }
}
