using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracTest_Tut13.Models
{
    public class OrderResponse
    { 
        public int IdOrder { get; set; }
        public string ConfectioneryName { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }
    }
}
