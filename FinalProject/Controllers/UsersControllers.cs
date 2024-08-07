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
        [HttpGet("user/{userid}", Name = "GetUser")]
        public async Task<Users> GetUser(string userid)
        {
            Users user = await _dbuser.GetUser(userid);
            return user;
        }

        [HttpGet("AllUsers/{userid}", Name = "GetAllUsers")]
        public async Task<IEnumerable<Users>> GetAllUsers(string userid)
        {
            var users = await _dbuser.GetAllUsers(userid);
            return users;
        }

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