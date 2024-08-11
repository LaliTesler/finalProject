using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DAL.Data
{
    public class UsersData : IUsers
    {
        private readonly ModelsContext _Context;
        private readonly IMapper _mapper;
        public UsersData(ModelsContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateUser(UsersDTO u)
        {
            if (!IsValidIsraeliId(u.userId))
            {
                return false;
            }
            await _Context.users.AddAsync(_mapper.Map<Users>(u));
            await _Context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUser(string id)
        {
            Users u = await _Context.users.FindAsync(id);
            if (u == null)
            {
                return false;
            }
            _Context.users.Remove(u);
            await _Context.SaveChangesAsync();
            return true;
        }
        public async Task<Users> GetUser(string id)
        {
            Users u = await _Context.users.FindAsync(id);
            if (u == null)
            {
                return null;
            }
            return u;
        }

        public async Task<IActionResult> GetAllUsers(string id)
        {
            var currentUser = await _Context.users.FindAsync(id);
            if (currentUser == null)
            {
                return new NotFoundObjectResult("Current user not found."); // מחזיר 404 אם המשתמש הנוכחי לא נמצא
            }

            if (currentUser.isAdmin == 0)
            {
                return new ObjectResult("You are not authorized to view all users.") { StatusCode = StatusCodes.Status403Forbidden }; // מחזיר 403 אם המשתמש לא מנהל
            }

            var users = await _Context.users.ToListAsync();
            if (users == null || !users.Any())
            {
                return new NotFoundObjectResult("No users found."); // מחזיר 404 אם לא נמצאו משתמשים
            }

            return new OkObjectResult(users); // מחזיר 200 עם רשימת המשתמשים
        }


        public async Task<bool> UpdateUser(string id, UsersDTO updateuser)
        {
            Users currentuser = await _Context.users.FindAsync(id);
            if (currentuser == null)
            {
                return false;
            }
            currentuser.userId =id ;
            currentuser.password = updateuser.password;
            currentuser.lastName = updateuser.lastName;
            currentuser.firstName = updateuser.firstName;
            currentuser.isAdmin=updateuser.isAdmin;

            await _Context.SaveChangesAsync();
            return true;
        }
        private bool IsValidIsraeliId(string id)
        {
            if (id.Length != 9 || !long.TryParse(id, out _))
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = id[i] - '0';
                if (i % 2 == 1)
                {
                    digit *= 2;
                }
                if (digit > 9)
                {
                    digit -= 9;
                }
                sum += digit;
            }

            return sum % 10 == 0;
        }
    }

}

