using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracTest_Tut13.Entities;
using PracTest_Tut13.Models;

namespace PracTest_Tut13.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ClientController(MyDbContext myDbContext)
        {
            _context = myDbContext;
        }
        [HttpPut("{clientid}")]
        public IActionResult addClient(String clientid) {

            ClientStructure enter = new ClientStructure

            {
                DateAccepted = DateTime.Parse("2020-06-01"),
                Notes = "Please, prepare for next friday",

                Quantity = 1,
                Name = "Cake for birthday",
                ConNotes = "Write Happy birthday on the cake"
            };

           var exc = _context.Customers.Find(clientid);
            if (exc is null) {
                return NotFound(" this Client does not exist in the database");
            }

            var od = new Order
            {
                DateAccepted = enter.DateAccepted,
                Notes = enter.Notes,
            };

            var con_od = new Confectionery_Order
            {
                Quantity = enter.Quantity,
                Notes = enter.ConNotes
            };

            var con = new Confectionery
            {
                Name = enter.Name
            };

            _context.Orders.Add(od);
            _context.Confectioneries.Add(con);
            _context.Confectionery_Orders.Add(con_od);

            _context.SaveChanges();

            return Ok("Order for the client has been successfully added");
        
    

        }

    }
}