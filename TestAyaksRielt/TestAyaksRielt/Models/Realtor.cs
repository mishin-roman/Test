using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAyaksRielt.Models
{
    public class Realtor
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateTime { get; set; }

        public long DivisionId { get; set; }
        public Division Division { get; set; }
        
       
       
    }       
}
