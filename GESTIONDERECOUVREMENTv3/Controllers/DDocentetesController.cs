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
    public class DDocentetesController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DDocentetesController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DDocentetes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DDocentete>>> GetDDocentete()
        {
            return await _context.DDocentetes.ToListAsync();
        }

        // GET: api/DDocentetes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DDocentete>> GetDDocentete(int id)
        {
            var dDocentete = await _context.DDocentetes.FindAsync(id);

            if (dDocentete == null)
            {
                return NotFound();
            }

            return dDocentete;
        }

      /*  // GET: api/DComptet/GetNB_CL_Relance
        [HttpGet("GetNB_CL_Relance/{i}/{type}")]
        public ActionResult GetNB_CL_Relance_TEL(int i, string type)
        {



            var result = (_context.DNotifications
                //.Where(d => d.)//condition de retard nb+8{i}
                .Include(d => d.NumScenarioNavigation).Where(num => num.NumScenarioNavigation.Type == 2 && num.NumScenarioNavigation.Media == type)
                .Count()
                );

            return Ok(result);
        }*/


      //ok
        // GET: api/total_restALLCLient_/5
        [HttpGet("GetSomme_Reste_ALLClient")]
        public decimal GetSomme_Reste_ALLClient()
        {
            var result = (_context.DDocentetes.Where(d =>  d.DoType == 6 && d.DoDomaine == 0)
               .Select(d => new
               {
                   d.DoMontantRest,
               }
                ));
            decimal x = 0;
            foreach (var o in result)
            {

                x = Decimal.Add(x, (decimal)o.DoMontantRest);
            }
            if (x == 0)
            {
                return -1;
            }
            else { return x; }

        }
        //ok
        // GET: api/GetSomme_Reste_Client/5
        [HttpGet("GetSomme_Reste_Client/{id}")]
        public decimal GetSomme_Reste_Client(string id)
        {


            List<string> l = new List<string>();
            var result = (_context.DDocentetes.Where(d =>  d.DoTiers == id && d.DoType == 6 && d.DoDomaine == 0)
               .Select(d => new
                { 
                   d.DoMontantRest,
                }
                ));
            decimal x = 0;
            foreach (var o in result)
            {
                
                x = Decimal.Add(x , (decimal)o.DoMontantRest);
            }
            if (x == 0)
            {
                return -1;
            }
            else { return x; }

        }
    

        // PUT: api/DDocentetes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDDocentete(int id, DDocentete dDocentete)
        {
            if (id != dDocentete.CbMarq)
            {
                return BadRequest();
            }

            _context.Entry(dDocentete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DDocenteteExists(id))
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

        // POST: api/DDocentetes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DDocentete>> PostDDocentete(DDocentete dDocentete)
        {
            _context.DDocentetes.Add(dDocentete);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDDocentete", new { id = dDocentete.CbMarq }, dDocentete);
        }

        // DELETE: api/DDocentetes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DDocentete>> DeleteDDocentete(int id)
        {
            var dDocentete = await _context.DDocentetes.FindAsync(id);
            if (dDocentete == null)
            {
                return NotFound();
            }

            _context.DDocentetes.Remove(dDocentete);
            await _context.SaveChangesAsync();

            return dDocentete;
        }

        private bool DDocenteteExists(int id)
        {
            return _context.DDocentetes.Any(e => e.CbMarq == id);
        }
    }
}
