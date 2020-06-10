using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracTest_Tut13.Entities
{
    public class Employee
    {
        public int IdEmpl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
