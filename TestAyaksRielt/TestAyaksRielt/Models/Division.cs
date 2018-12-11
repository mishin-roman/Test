using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAyaksRielt.Models
{
    public class Division
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }

        public ICollection<Realtor> Realtors { get; set; }
    }
}
