using DAL.DTO;
using Microsoft.AspNetCore.Mvc;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsers
    {
        Task<bool> CreateUser(UsersDTO c);
        Task<bool> DeleteUser(string id);
        Task<Users> GetUser(string id);
        Task<bool> UpdateUser(string id, UsersDTO updatecv);
        Task<IActionResult> GetAllUsers(string id);

    }
}
