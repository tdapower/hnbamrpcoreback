using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MRPSystemBackend.API.MedicalLetter
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicalLetterController : Controller
    {
        IMedicalLetterRepository medicalLetterRepository;

        public MedicalLetterController(IMedicalLetterRepository _medicalLetterRepository)
        {
            medicalLetterRepository = _medicalLetterRepository;
        }

        [HttpPost]
        [Route("AddMedicalLetter")]
        public IActionResult AddMedicalLetter([FromBody] MedicalLetter medicalLetter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = medicalLetterRepository.CreateMedicalLetter(medicalLetter);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        [HttpPost]
        [Route("UpdateMedicalLetter")]
        public IActionResult UpdateMedicalLetter([FromBody] MedicalLetter medicalLetter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = medicalLetterRepository.UpdateMedicalLetter(medicalLetter);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }

    }
}