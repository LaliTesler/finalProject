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
        public long id { get; set; }
        public long userId { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
  
    }
}
