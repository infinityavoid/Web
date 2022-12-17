using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using automastAPI.Models;

namespace automastAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SparePartsController : Controller
    {
        private readonly DataDbContext _context;

        public SparePartsController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.SpareParts.ToListAsync());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _context.SpareParts.FindAsync(id);
            if (id != result.SparePartId || result.Amount == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("SparePartId,SpareName,Cost,Amount,Quantity")] SparePart sparePart)
        {
            _context.Add(sparePart);
            await _context.SaveChangesAsync();
            return Ok(sparePart);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [Bind("SparePartId,SpareName,Cost,Amount,Quantity")] SparePart sparePart)
        {
            if (id != sparePart.SparePartId)
            {
                return NotFound();
            }
            else
            {
                _context.Update(sparePart);
                await _context.SaveChangesAsync();
                return Ok(sparePart);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var sparePart = await _context.SpareParts.FindAsync(id);
            if (sparePart != null)
            {
                _context.SpareParts.Remove(sparePart);
                await _context.SaveChangesAsync();
                return Ok(sparePart);
            }
            return NotFound();
        }
    }
}
