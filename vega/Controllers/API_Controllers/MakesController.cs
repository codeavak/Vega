using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Models;

namespace vega.Controllers.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly VegaContext _context;

        public MakesController(VegaContext context)
        {
            _context = context;
        }

        // GET: api/Makes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        {
            return await _context.Makes.Include(i=>i.Models).ToListAsync();
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Make>> GetMake(int id)
        {
            var make = await _context.Makes.FindAsync(id);

            if (make == null)
            {
                return NotFound();
            }

            return make;
        }

        // PUT: api/Makes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Make make)
        {
            if (id != make.Id)
            {
                return BadRequest();
            }

            _context.Entry(make).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MakeExists(id))
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

        // POST: api/Makes
        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Make make)
        {
            _context.Makes.Add(make);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMake", new { id = make.Id }, make);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Make>> DeleteMake(int id)
        {
            var make = await _context.Makes.FindAsync(id);
            if (make == null)
            {
                return NotFound();
            }

            _context.Makes.Remove(make);
            await _context.SaveChangesAsync();

            return make;
        }

        private bool MakeExists(int id)
        {
            return _context.Makes.Any(e => e.Id == id);
        }
    }
}
