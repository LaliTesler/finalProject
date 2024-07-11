﻿using DAL.DTO;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS.Models;
namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersControllers : ControllerBase
    {
        private readonly IUsers _dbuser;
        public UsersControllers(IUsers user)
        {
            _dbuser = user;
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool delete = await _dbuser.DeleteUser(id);
            if (delete)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            Users user = await _dbuser.GetUser(id);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UsersDTO value)
        {
            bool update = await _dbuser.UpdateUser(id, value);
            if (update)
            {
                return Ok();
            }
            return BadRequest();
        }


    }
}