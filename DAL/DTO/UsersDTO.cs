using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS.Models;


namespace DAL.DTO
{
    public class UsersDTO
    {
        public string userId { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int isAdmin { get; set; }


    }
}
