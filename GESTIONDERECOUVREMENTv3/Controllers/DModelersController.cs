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
    public class DModelersController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DModelersController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DModelers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DModeler>>> GetDModeler()
        {
            return await _context.DModelers.ToListAsync();
        }

        // GET: api/DModelers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DModeler>> GetDModeler(int id)
        {
            var dModeler = await _context.DModelers.FindAsync(id);

            if (dModeler == null)
            {
                return NotFound();
            }

            return dModeler;
        }

        // PUT: api/DModelers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDModeler(int id, DModeler dModeler)
        {
            if (id != dModeler.MrNo)
            {
                return BadRequest();
            }

            _context.Entry(dModeler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DModelerExists(id))
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

        // POST: api/DModelers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DModeler>> PostDModeler(DModeler dModeler)
        {
            _context.DModelers.Add(dModeler);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DModelerExists(dModeler.MrNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDModeler", new { id = dModeler.MrNo }, dModeler);
        }

        // DELETE: api/DModelers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DModeler>> DeleteDModeler(int id)
        {
            var dModeler = await _context.DModelers.FindAsync(id);
            if (dModeler == null)
            {
                return NotFound();
            }

            _context.DModelers.Remove(dModeler);
            await _context.SaveChangesAsync();

            return dModeler;
        }

        private bool DModelerExists(int id)
        {
            return _context.DModelers.Any(e => e.MrNo == id);
        }
    }
}
