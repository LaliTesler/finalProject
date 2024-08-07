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
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(string userid)
        {
            bool delete=await _dbCV.DeleteCV(userid);
            if (delete)
                return Ok();
            return BadRequest();
        }
        [HttpGet("CV/{id}")]
        public async Task<CV> Get(string userid)
        {
            CV cv = await _dbCV.GetCVById(userid);
            return cv;
        }
        [HttpGet("AllCV")]
        public async Task<IEnumerable<CV>> Get( )
        {
            var cv = await _dbCV.GetAllCV();

            return cv;
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
