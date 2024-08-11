using DAL.DTO;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS.Models;

namespace FinalProject.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class CVControllers : ControllerBase
    {
        private readonly ICV _dbCV;
        public CVControllers(ICV cv)
        {
            _dbCV = cv;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CVDTO value)
        {
            bool creat = await _dbCV.CreateCV(value);
            if (creat)
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{userid}")]
        public async Task<IActionResult>Delete(string userid)
        {
            bool delete=await _dbCV.DeleteCV(userid);
            if (delete)
                return Ok();
            return BadRequest();
        }
        [HttpGet("CV/{id}")]
       
        public async Task<IActionResult> GetCVByID(string userId)
        {
            CV cv = await _dbCV.GetCVById(userId);
            if (cv == null)
            {
                return NotFound(); // מחזיר 404 אם קורות החיים לא נמצאו
            }
            return Ok(cv); // מחזיר 200 עם אובייקט קורות החיים
        }

        [HttpGet("AllCV")]
        public async Task<IActionResult> GetAllCV()
        {
            var cvList = await _dbCV.GetAllCV();

            if (cvList == null || !cvList.Any())
            {
                return NotFound("No CVs found."); // מחזיר 404 אם אין קורות חיים
            }

            return Ok(cvList); // מחזיר 200 עם רשימת קורות החיים
        }

        [HttpPut("{userid}")]
        public async Task<IActionResult> Put(string userid, [FromBody] CVDTO value)
        {
            bool update=await _dbCV.UpdateCV(userid, value);
            if(update)
                return Ok();
            return BadRequest();
        }


    }
}
