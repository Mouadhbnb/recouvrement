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
    public class DEmodelersController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DEmodelersController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DEmodelers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DEmodeler>>> GetDEmodeler()
        {
            return await _context.DEmodelers.ToListAsync();
        }

        // GET: api/DEmodelers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DEmodeler>> GetDEmodeler(int id)
        {
            var dEmodeler = await _context.DEmodelers.FindAsync(id);

            if (dEmodeler == null)
            {
                return NotFound();
            }

            return dEmodeler;
        }

        // PUT: api/DEmodelers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDEmodeler(int id, DEmodeler dEmodeler)
        {
            if (id != dEmodeler.MrNo)
            {
                return BadRequest();
            }

            _context.Entry(dEmodeler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DEmodelerExists(id))
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

        // POST: api/DEmodelers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DEmodeler>> PostDEmodeler(DEmodeler dEmodeler)
        {
            _context.DEmodelers.Add(dEmodeler);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DEmodelerExists(dEmodeler.MrNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDEmodeler", new { id = dEmodeler.MrNo }, dEmodeler);
        }

        // DELETE: api/DEmodelers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DEmodeler>> DeleteDEmodeler(int id)
        {
            var dEmodeler = await _context.DEmodelers.FindAsync(id);
            if (dEmodeler == null)
            {
                return NotFound();
            }

            _context.DEmodelers.Remove(dEmodeler);
            await _context.SaveChangesAsync();

            return dEmodeler;
        }

        private bool DEmodelerExists(int id)
        {
            return _context.DEmodelers.Any(e => e.MrNo == id);
        }
    }
}
