using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracTest_Tut13.Entities
{
    public class Confectionery_Order
    {
        [ForeignKey("Confectionery")]
        public int IdConfection { get; set; }
        [ForeignKey("Order")]
        public int IdOrder { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }

        public virtual Confectionery Confectionery { get; set; }
        public virtual Order Order { get; set; }

    }
}
