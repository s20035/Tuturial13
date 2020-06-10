using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracTest_Tut13.Entities;
using PracTest_Tut13.Models;

namespace PracTest_Tut13.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MyDbContext _context;
        public OrderController(MyDbContext myDbContext) {
            _context = myDbContext;
        }
        [HttpGet]
        public IActionResult getOrder() {

            var orders = _context.Confectionery_Orders.Include(s => s.Order).Include(s => s.Confectionery)
                .Select(g => new OrderResponse
                {
                    IdOrder = g.IdOrder,
                    ConfectioneryName = g.Confectionery.Name,
                    DateAccepted = g.Order.DateAccepted,
                    DateFinished = g.Order.DateFinished,
                    Notes = g.Order.Notes

                }).ToList();

            return Ok(orders);
        }
    }
}