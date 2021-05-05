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
    public class DReglechesController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DReglechesController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DRegleches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DReglech>>> GetDReglech()
        {
            return await _context.DRegleches.ToListAsync();
        }

        // GET: api/DRegleches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DReglech>> GetDReglech(int id)
        {
            var dReglech = await _context.DRegleches.FindAsync(id);

            if (dReglech == null)
            {
                return NotFound();
            }

            return dReglech;
        }
        //ok
        // GET: api/DCreglement/Gettotalpaye
       [HttpGet("Gettotalpaye/{dateini}/{datefin}")]
        public decimal Gettotalpayet(DateTime dateini, DateTime datefin)
        {

            var result = _context.DRegleches.Where(d => d.CbModification.Value.Date >=dateini.Date && d.CbModification.Value.Date <= datefin.Date)
                .Select(d => new
                {
                    d.RcMontantImpute
                }
                );
            decimal x = 0;
            foreach (var o in result)
            {

                x = Decimal.Add(x, (decimal)o.RcMontantImpute);
            }
            if (x == 0)
            {
                return -1;
            }
            else { return x; }


        }



            // PUT: api/DRegleches/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
        public async Task<IActionResult> PutDReglech(int id, DReglech dReglech)
        {
            if (id != dReglech.CbMarq)
            {
                return BadRequest();
            }

            _context.Entry(dReglech).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DReglechExists(id))
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

        // POST: api/DRegleches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DReglech>> PostDReglech(DReglech dReglech)
        {
            _context.DRegleches.Add(dReglech);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDReglech", new { id = dReglech.CbMarq }, dReglech);
        }

        // DELETE: api/DRegleches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DReglech>> DeleteDReglech(int id)
        {
            var dReglech = await _context.DRegleches.FindAsync(id);
            if (dReglech == null)
            {
                return NotFound();
            }

            _context.DRegleches.Remove(dReglech);
            await _context.SaveChangesAsync();

            return dReglech;
        }

        private bool DReglechExists(int id)
        {
            return _context.DRegleches.Any(e => e.CbMarq == id);
        }
    }
}
