using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MRPSystemBackend.API.MedicalTest
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicalTestController : ControllerBase
    {
        IMedicalTestRepository medicalTestRepository;

        public MedicalTestController(IMedicalTestRepository _medicalTestRepository)
        {
            medicalTestRepository = _medicalTestRepository;
        }

        [HttpGet]
        [Route("GetAllMedicalTests")]
        public IActionResult GetHospitals()
        {
            var result = medicalTestRepository.GetMedicalTests();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }



    }
}