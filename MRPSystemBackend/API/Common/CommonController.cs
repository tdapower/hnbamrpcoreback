using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MRPSystemBackend.API.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CommonController : Controller
    {

        ICommonRepository commonRepository;
        public CommonController(ICommonRepository _commonRepository)
        {
            commonRepository = _commonRepository;
        }

        [HttpGet]
        [Route("GetNationalityList")]
        public IActionResult GetNationalityList()
        {
            var result = commonRepository.GetAllNationalities();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllBanks")]
        public IActionResult GetAllBanks()
        {
            var result = commonRepository.GetAllBanks();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllBankBranches")]
        public IActionResult GetAllBankBranches()
        {
            var result = commonRepository.GetAllBankBranches();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetBankBranchesOfBank/{bankId}")]
        public IActionResult GetBankBranchesOfBank(int bankId)
        {
            var result = commonRepository.GetBankBranchesOfBank(bankId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllBrokers")]
        public IActionResult GetAllBrokers()
        {
            var result = commonRepository.GetAllBrokers();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllBusinessChannels")]
        public IActionResult GetAllBusinessChannels()
        {
            var result = commonRepository.GetAllBusinessChannels();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllModeOfProposals")]
        public IActionResult GetAllModeOfProposals()
        {
            var result = commonRepository.GetAllModeOfProposals();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllMRPUsers")]
        public IActionResult GetAllMRPUsers()
        {
            var result = commonRepository.GetAllMRPUsers();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet]
        [Route("GetPendingJobsOfUsers")]
        public IActionResult GetPendingJobsOfUsers()
        {
            var result = commonRepository.GetPendingJobsOfUsers();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}