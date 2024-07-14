using DAL.DTO;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS.Models;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVJobsControllers : ControllerBase
    {

        private readonly ICVJobs _dbCV;
        public CVJobsControllers(ICVJobs cv)
        {
            _dbCV = cv;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CVJobsDTO value)
        {
            bool creat = await _dbCV.CreateCVJobs(value);
            if (creat)
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool delete = await _dbCV.DeleteCVJobs(id);
            if (delete == true)
                return Ok();
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            CVJobs cv = await _dbCV.GetCVJobs(id);
            if (cv == null)
                return BadRequest();
            return Ok(cv);
        }

    }
}