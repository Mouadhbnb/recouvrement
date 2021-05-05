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
    public class DDoclignesController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DDoclignesController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DDoclignes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DDocligne>>> GetDDocligne()
        {
            return await _context.DDoclignes.ToListAsync();
        }

        // GET: api/DDoclignes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DDocligne>> GetDDocligne(int id)
        {
            var dDocligne = await _context.DDoclignes.FindAsync(id);

            if (dDocligne == null)
            {
                return NotFound();
            }

            return dDocligne;
        }

        // PUT: api/DDoclignes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDDocligne(int id, DDocligne dDocligne)
        {
            if (id != dDocligne.CbMarq)
            {
                return BadRequest();
            }

            _context.Entry(dDocligne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DDocligneExists(id))
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

        // POST: api/DDoclignes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DDocligne>> PostDDocligne(DDocligne dDocligne)
        {
            _context.DDoclignes.Add(dDocligne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDDocligne", new { id = dDocligne.CbMarq }, dDocligne);
        }

        // DELETE: api/DDoclignes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DDocligne>> DeleteDDocligne(int id)
        {
            var dDocligne = await _context.DDoclignes.FindAsync(id);
            if (dDocligne == null)
            {
                return NotFound();
            }

            _context.DDoclignes.Remove(dDocligne);
            await _context.SaveChangesAsync();

            return dDocligne;
        }

        private bool DDocligneExists(int id)
        {
            return _context.DDoclignes.Any(e => e.CbMarq == id);
        }
    }
}
