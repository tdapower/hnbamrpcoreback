using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MRPSystemBackend.API.Hospital
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class HospitalController : Controller
    {
        IHospitalRepository hospitalRepository;

        public HospitalController(IHospitalRepository _hospitalRepository)
        {
            hospitalRepository = _hospitalRepository;
        }

        [HttpGet]
        [Route("GetHospital/{hospitalId}")]
        public IActionResult GetHospital(int hospitalId)
        {
            var result = hospitalRepository.GetHospitalById(hospitalId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetHospitals")]
        public IActionResult GetHospitals()
        {
            var result = hospitalRepository.GetHospitals();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }



        [HttpPost]
        [Route("SearchHospital")]
        public IActionResult SearchAssures([FromBody] SearchHospital searchHospital)
        {
            var result = hospitalRepository.SearchHospitals(searchHospital);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        [Route("AddHospital")]
        public IActionResult AddHospital([FromBody] Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = hospitalRepository.AddHospital(hospital);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        [HttpPut]
        [Route("UpdateHospital")]
        public IActionResult UpdateHospital([FromBody] Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = hospitalRepository.UpdateHospital(hospital);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }




        



    }
}