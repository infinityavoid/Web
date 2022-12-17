using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using automastAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace automastAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : Controller
    {
        private readonly DataDbContext _context;

        public BrandsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Brands
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Brands.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("BrandId,BrandName")] Brand brand)
        {
            _context.Add(brand);
            await _context.SaveChangesAsync();
            return Ok(brand);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [Bind("BrandId,BrandName")] Brand brand)
        {
            if (id != brand.BrandId)
            {
                return NotFound();
            }
            else
            {
                _context.Update(brand);
                await _context.SaveChangesAsync();
                return Ok(brand);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
                return Ok(brand);
            }
            return NotFound();
        }
    }
}
