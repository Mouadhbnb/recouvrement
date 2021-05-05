using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GESTIONDERECOUVREMENT.Models;

namespace GESTIONDERECOUVREMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DEmployesController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DEmployesController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DEmployes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DEmploye>>> GetDEmployes()
        {
            return await _context.DEmployes.ToListAsync();
        }

        // GET: api/DEmployes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DEmploye>> GetDEmployes(int id)
        {
            var dEmployes = await _context.DEmployes.FindAsync(id);

            if (dEmployes == null)
            {
                return NotFound();
            }

            return dEmployes;
        }

        // PUT: api/DEmployes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDEmployes(int id, DEmploye dEmployes)
        {
            if (id != dEmployes.CbMarq)
            {
                return BadRequest();
            }

            _context.Entry(dEmployes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DEmployesExists(id))
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

        // POST: api/DEmployes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DEmploye>> PostDEmployes(DEmploye dEmployes)
        {
            _context.DEmployes.Add(dEmployes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDEmployes", new { id = dEmployes.CbMarq }, dEmployes);
        }

        // DELETE: api/DEmployes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DEmploye>> DeleteDEmployes(int id)
        {
            var dEmployes = await _context.DEmployes.FindAsync(id);
            if (dEmployes == null)
            {
                return NotFound();
            }

            _context.DEmployes.Remove(dEmployes);
            await _context.SaveChangesAsync();

            return dEmployes;
        }

        private bool DEmployesExists(int id)
        {
            return _context.DEmployes.Any(e => e.CbMarq == id);
        }
    }
}
