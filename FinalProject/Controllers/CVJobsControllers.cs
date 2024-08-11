using DAL.DTO;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MODELS.Models;

namespace FinalProject.Controllers
{
    [Authorize]

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
            var cvJobs = await _dbCV.GetCVJobs(id);

            if (cvJobs == null || !cvJobs.Any())
            {
                return NotFound("No CV jobs found for the given ID."); // מחזיר 404 אם לא נמצאו משרות לקורות החיים
            }

            return Ok(cvJobs); // מחזיר 200 עם רשימת המשרות לקורות החיים
        }

    }
}