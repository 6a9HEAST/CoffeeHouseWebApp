using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using WebLab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace WebLab2.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class OrderLinesController : ControllerBase
    {
        private readonly CoffeeHouseContext _context;
        public OrderLinesController(CoffeeHouseContext context)
        {
            _context = context;
        }

        // GET: api/OrderLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLine>>> GetOrderLine()
        {
            return await _context.OrderLines.ToListAsync();
        }
        // GET: api/OrderLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderLine>> GetOrderLine(int id)
        {
            var orderLine = await _context.OrderLines.FindAsync(id);
            if (orderLine == null)
            {
                return NotFound();
            }
            return orderLine;
        }

        // POST: api/OrderLines
        [HttpPost]
        public async Task<ActionResult<OrderLine>> AddOrderLine(OrderLine orderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.OrderLines.Add(orderLine);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrderLine", new { id = orderLine.Id }, orderLine);
        }

        // PUT: api/OrderLines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderLine(int id, OrderLine orderLine)
        {
            if (id != orderLine.Id)
            {
                return BadRequest();
            }
            _context.Entry(orderLine).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool OrderLineExists(int id)
        {
            return _context.OrderLines.Any(e => e.Id == id);
        }

        // DELETE: api/OrderLines/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteOrderLine(int id)
        {
            var orderLine = await _context.OrderLines.FindAsync(id);
            if (orderLine == null)
            {
                return NotFound();
            }
            _context.OrderLines.Remove(orderLine);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
