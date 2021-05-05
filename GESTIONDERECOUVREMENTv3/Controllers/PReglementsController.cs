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
    public class PReglementsController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public PReglementsController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/PReglements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PReglement>>> GetPReglement()
        {
            return await _context.PReglements.ToListAsync();
        }

        // GET: api/PReglements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PReglement>> GetPReglement(int id)
        {
            var pReglement = await _context.PReglements.FindAsync(id);

            if (pReglement == null)
            {
                return NotFound();
            }

            return pReglement;
        }

        // PUT: api/PReglements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPReglement(int id, PReglement pReglement)
        {
            if (id != pReglement.CbMarq)
            {
                return BadRequest();
            }

            _context.Entry(pReglement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PReglementExists(id))
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

        // POST: api/PReglements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PReglement>> PostPReglement(PReglement pReglement)
        {
            _context.PReglements.Add(pReglement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPReglement", new { id = pReglement.CbMarq }, pReglement);
        }

        // DELETE: api/PReglements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PReglement>> DeletePReglement(int id)
        {
            var pReglement = await _context.PReglements.FindAsync(id);
            if (pReglement == null)
            {
                return NotFound();
            }

            _context.PReglements.Remove(pReglement);
            await _context.SaveChangesAsync();

            return pReglement;
        }

        private bool PReglementExists(int id)
        {
            return _context.PReglements.Any(e => e.CbMarq == id);
        }
    }
}
