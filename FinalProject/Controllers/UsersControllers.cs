using DAL.DTO;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersControllers : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        
        private readonly IUsers _dbuser;
        public UsersControllers(IUsers user, IServiceProvider serviceProvider)
        {
            _dbuser = user;
            _serviceProvider = serviceProvider;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsersDTO value)
        {
            bool create = await _dbuser.CreateUser(value);
            if (create)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]

        [HttpDelete("{userid}")]
        public async Task<IActionResult> Delete(string userid)
        {
            bool delete = await _dbuser.DeleteUser(userid);
            if (delete)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]

        [HttpGet("user/{userid}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string userId)
        {
            Users user = await _dbuser.GetUser(userId);

            if (user == null)
            {
                return NotFound("User not found."); // מחזיר 404 אם המשתמש לא נמצא
            }

            return Ok(user); // מחזיר 200 עם אובייקט המשתמש
        }


        [Authorize]

        [HttpGet("AllUsers/{userId}", Name = "GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(string userId)
        {
            var result = await _dbuser.GetAllUsers(userId);

            if (result is NotFoundResult)
            {
                return NotFound("No users found."); // מחזיר 404 אם לא נמצאו משתמשים
            }

            if (result is ForbidResult)
            {
                return Forbid("You are not authorized to view all users."); // מחזיר 403 אם המשתמש לא מנהל
            }

            return Ok(result); // מחזיר 200 עם רשימת המשתמשים
        }

        [Authorize]

        [HttpPut("{userid}")]
        public async Task<IActionResult> Put(string userid, [FromBody] UsersDTO value)
        {
            bool update = await _dbuser.UpdateUser(userid, value);
            if (update)
            {
                return Ok();
            }
            return BadRequest();
        }


    }
}