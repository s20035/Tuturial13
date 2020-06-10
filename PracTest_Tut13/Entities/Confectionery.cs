using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracTest_Tut13.Entities
{
    public class Confectionery
    {
        public int IdConfection { get; set; }
        public string Name { get; set; }
        public double PricePerite { get; set; }
        public string Type { get; set; }

        public virtual Confectionery_Order Confectionery_Order { get; set; }
    }
}
