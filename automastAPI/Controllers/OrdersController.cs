using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using automastAPI.Models;

namespace automastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataDbContext _context;

        public OrdersController(DataDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Orders.ToListAsync());
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [Bind("OrderId,Products,Date,Completed,Installation,Cost")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }
            else
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
                return Ok(order);
            }
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> Create([Bind("OrderId,Products,Date,Completed,Installation,Cost")] Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
            return Ok(order);
        }

        // DELETE: api/Orders/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return Ok(order);
            }
            return NotFound();
        }
    }
}
