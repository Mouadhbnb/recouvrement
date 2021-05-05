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
    public class DScenariosController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DScenariosController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DScenarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DScenario>>> GetDScenario()
        {
            return await _context.DScenarios.ToListAsync();
        }

        // GET: api/DScenarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DScenario>> GetDScenario(string id)
        {
            var dScenario = await _context.DScenarios.FindAsync(id);

            if (dScenario == null)
            {
                return NotFound();
            }

            return dScenario;
        }

        [HttpGet("Post_scenario/{ct_num}/{Type_scenario}/{NB_Jour}/{Date}/{Media}/{ENVOIE_Auto}/{contenue}")]
        public ActionResult Post_scenario(string ct_num, int Type_scenario, int NB_Jour, DateTime Date, int Media, int ENVOIE_Auto, string contenue)
        {
            var dcomptet = _context.DComptets
                .Where(d => d.CtNum == ct_num);

            DAttachement dt = new DAttachement();
            dt.Contenu = contenue;
            _context.DAttachements.Add(dt);
            _context.SaveChanges();
            var scenario = new DScenario();


            scenario.Type = Type_scenario;
            scenario.NbJour = NB_Jour;
            scenario.Date = Date;
            scenario.Media = Media;
            scenario.EnvoieAuto = ENVOIE_Auto;
            scenario.IdAttachement = dt.IdAtt;
            DNotification dn = new DNotification();
            dn.CtNum = ct_num;
            scenario.DNotifications.Add(dn);
            _context.DScenarios.Add(scenario);
            _context.SaveChanges();

      
            var result = (_context.DNotifications
                .Where(d => d.CtNum == ct_num)
                .Include(d => d.NumScenarioNavigation)
                .ThenInclude(d=>d.IdAttachementNavigation)
                .Select(d => new
                {
                    d.CtNum,
                    d.NumScenarioNavigation.NumScenario,
                    d.NumScenarioNavigation.Type,
                    d.NumScenarioNavigation.NbJour,
                    d.NumScenarioNavigation.Date,
                    d.NumScenarioNavigation.Media,
                    d.NumScenarioNavigation.EnvoieAuto,
                    d.NumScenarioNavigation.IdAttachement,
                    d.NumScenarioNavigation.IdAttachementNavigation.Contenu,
                })
                );

            if (result == null)
            {
                return NotFound();
            }
            else { return Ok(result); }

        }

       






        // PUT: api/DScenarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDScenario(int id, DScenario dScenario)
        {
            if (id != dScenario.NumScenario)
            {
                return BadRequest();
            }

            _context.Entry(dScenario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
              
                    throw;
                
            }

            return NoContent();
        }

   /*     // POST: api/DScenarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DScenario>> PostDScenario(DScenario dScenario)
        {
            _context.DScenarios.Add(dScenario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                
                    throw;
                
            }

            return CreatedAtAction("GetDScenario", new { id = dScenario.NumScenario }, dScenario);
        }
   */
        // DELETE: api/DScenarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DScenario>> DeleteDScenario(string id)
        {
            var dScenario = await _context.DScenarios.FindAsync(id);
            if (dScenario == null)
            {
                return NotFound();
            }

            _context.DScenarios.Remove(dScenario);
            await _context.SaveChangesAsync();

            return dScenario;
        }

        private bool DScenarioExists(int id)
        {
            return _context.DScenarios.Any(e => e.NumScenario == id);
        }
    }
}
