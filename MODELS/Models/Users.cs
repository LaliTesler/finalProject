using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models
{
    public class Users
    {

       
        public long id { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public CV usercv { get; set; }
        public virtual ICollection<Job> userJobs { get; set; }
        public virtual ICollection<Job> saveJobs { get; set; }


    }
}
