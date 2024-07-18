using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class CVDTO
    {
        public long id { get; set; }
        public long userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mail { get; set; }
        public int phon { get; set; }
        public string profile { get; set; }
        public string skills { get; set; }
        public string PracticalExperience { get; set; }
        public string education { get; set; }
        public string language { get; set; }


    }
}
