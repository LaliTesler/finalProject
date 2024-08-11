using DAL.DTO;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS.Models;
using Microsoft.AspNetCore.Authorization;


namespace FinalProject.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class JobControllers : ControllerBase
    {
        private readonly IJob _dbJob;
        public JobControllers(IJob job)
        {
            _dbJob = job;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobDTO value)
        {
            bool creat = await _dbJob.CreateJob(value);
            if (creat)
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool delete = await _dbJob.DeleteJob(id);
            if (delete)
                return Ok();
            return BadRequest();
        }
        [HttpGet("job/{id}", Name = "GetJob")]
        public async Task<IActionResult> GetJob(long id)
        {
            Job job = await _dbJob.GetJob(id);

            if (job == null)
            {
                return NotFound("Job not found."); // מחזיר 404 אם המשרה לא נמצאה
            }

            return Ok(job); // מחזיר 200 עם אובייקט המשרה
        }

        [HttpGet("AllJobsById/{id}", Name = "GetAllJobs")]
        public async Task<IActionResult> GetAllJobsById(string userId)
        {
            var jobs = await _dbJob.GetAllJobsById(userId);

            if (jobs == null || !jobs.Any())
            {
                return NotFound("No jobs found for the given user ID."); // מחזיר 404 אם לא נמצאו משרות
            }

            return Ok(jobs); // מחזיר 200 עם רשימת המשרות
        }

        [HttpGet("AllJobs")]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _dbJob.GetAllJobs();

            if (jobs == null || !jobs.Any())
            {
                return NotFound("No jobs found."); // מחזיר 404 אם לא נמצאו משרות
            }

            return Ok(jobs); // מחזיר 200 עם רשימת המשרות
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] JobDTO value)
        {
            bool update = await _dbJob.UpdateJob(id, value);
            if (update)
                return Ok();
            return BadRequest();
        }




    }
}
