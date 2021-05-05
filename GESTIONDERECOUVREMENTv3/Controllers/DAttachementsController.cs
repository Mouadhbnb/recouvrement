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
    public class DAttachementsController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DAttachementsController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DAttachements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAttachement>>> GetDAttachement()
        {
            return await _context.DAttachements.ToListAsync();
        }

        // GET: api/DAttachements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DAttachement>> GetDAttachement(string id)
        {
            var dAttachement = await _context.DAttachements.FindAsync(id);

            if (dAttachement == null)
            {
                return NotFound();
            }

            return dAttachement;
        }



        // PUT: api/DAttachements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDAttachement(int id, DAttachement dAttachement)
        {
            if (id != dAttachement.IdAtt)
            {
                return BadRequest();
            }

            _context.Entry(dAttachement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DAttachementExists(id))
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
/*
        // POST: api/DAttachements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DAttachement>> PostDAttachement(DAttachement dAttachement)
        {
            _context.DAttachements.Add(dAttachement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DAttachementExists(dAttachement.IdAtt))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDAttachement", new { id = dAttachement.IdAtt }, dAttachement);
        }
*/
        // DELETE: api/DAttachements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DAttachement>> DeleteDAttachement(int id)
        {
            var dAttachement = await _context.DAttachements.FindAsync(id);
            if (dAttachement == null)
            {
                return NotFound();
            }

            _context.DAttachements.Remove(dAttachement);
            await _context.SaveChangesAsync();

            return dAttachement;
        }

        private bool DAttachementExists(int id)
        {
            return _context.DAttachements.Any(e => e.IdAtt == id);
        }
    }
}
