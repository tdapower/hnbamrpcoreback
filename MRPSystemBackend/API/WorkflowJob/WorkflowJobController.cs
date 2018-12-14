using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MRPSystemBackend.API.WorkflowJob
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class WorkflowJobController : Controller
    {
        IWorkflowJobRepository workflowJobRepository;

        public WorkflowJobController(IWorkflowJobRepository _workflowJobRepository)
        {
            workflowJobRepository = _workflowJobRepository;
        }


        [HttpPost]
        [Route("CreateWorkflowJob")]
        public IActionResult CreateWorkflowJob(WorkflowJob workflowJob)
        {

            var result = workflowJobRepository.CreateWorkflowJob(workflowJob);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        [Route("SearchWorkflowJob")]
        public IActionResult SearchWorkflowJob([FromBody] SearchWorkflowJob searchWorkflowJob)
        {
            var result = workflowJobRepository.SearchWorkflowJob(searchWorkflowJob);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUnassWorkflowJobs")]
        public IActionResult GetUnassWorkflowJobs()
        {
            var result = workflowJobRepository.GetUnassWorkflowJobs();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        [Route("GetWorkflowJob")]
        public IActionResult GetWorkflowJob([FromBody]string jobNo)
        {
            var result = workflowJobRepository.GetWorkflowjobByJobNo(jobNo);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPut]
        [Route("UpdateWorkflowJob")]
        public IActionResult UpdateWorkflowJob([FromBody] WorkflowJob workflowJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = workflowJobRepository.UpdateWorkflowJob(workflowJob);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}