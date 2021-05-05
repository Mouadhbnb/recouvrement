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
    public class DMecheancesController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DMecheancesController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DMecheances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DMecheance>>> GetDMecheance()
        {
            return await _context.DMecheances.ToListAsync();
        }

        // GET: api/DMecheances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DMecheance>> GetDMecheance(int id)
        {
            var dMecheance = await _context.DMecheances.FindAsync(id);

            if (dMecheance == null)
            {
                return NotFound();
            }

            return dMecheance;
        }

        //ok
        // GET: api/DCreglement/montant_Retard_parClient/5
        [HttpGet("Montant_Retard_parClient/{ct_num}")]
        public decimal Montant_Retard_parClient(string ct_num)
        {

            var result = _context.DMecheances.Where( d=>d.MeDatePrevu < DateTime.Today.Date && d.CtNum==ct_num && d.MeMontantReste!=0 )   
                .Select(d => new
                {
                    d.MeMontantReste
                }
                );
            decimal x = 0;
            foreach (var o in result)
            {

                x = Decimal.Add(x, (decimal)o.MeMontantReste);
            }
            if (x == 0)
            {
                return -1;
            }
            else { return x; }


        }
        //ok
        // return ct_num + date decheance
        // GET: api/DCreglement/montant_Retard_parClient/5
        [HttpGet("ALLClient_Retard")]
        public ActionResult ALLClient_Retard()
        {

            var result = _context.DMecheances.Where(d => d.MeDatePrevu < DateTime.Today.Date && d.MeMontantReste != 0)  
                .Select(d => new
                {
                    d.CtNum,
                    d.MeDatePrevu,
                    d.MeMontantReste
                }
                );
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }

        }
        // ok 
        // GET: api/DMecheances/montant_avenir_ALLClient/
        [HttpGet("Montant_Avenir_ALLClient")]
        public decimal Montant_Avenir_ALLClient()
        {

            var result = _context.DMecheances.Where(d => d.MeDatePrevu >= DateTime.Today.Date  && d.MeMontantReste != 0)
                .Select(d => new
                {
                    d.MeMontantReste
                }
                );
            decimal x = 0;
            foreach (var o in result)
            {

                x = Decimal.Add(x, (decimal)o.MeMontantReste);
            }
            if (x == 0)
            {
                return -1;
            }
            else { return x; }


        }
        // ok 
        // GET: api/DMecheances/montant_avenir_parClient/5
        [HttpGet("Montant_Avenir_parClient/{ct_num}")]
        public decimal Montant_Avenir_parClient(string ct_num)
        {

            var result = _context.DMecheances.Where(d => d.MeDatePrevu >= DateTime.Today.Date && d.CtNum == ct_num && d.MeMontantReste != 0)   //.Where(d => d.CbModification.Value - DateTime.Today <= (nbjour ou nbmois*30)
                .Select(d => new
                {
                    d.MeMontantReste
                }
                );
            decimal x = 0;
            foreach (var o in result)
            {

                x = Decimal.Add(x, (decimal)o.MeMontantReste);
            }
            if (x == 0)
            {
                return -1;
            }
            else { return x; }


        }
        //pk
        [HttpGet("promesse/{me_no}/{date_promis}/{montant_promis}")]
        public ActionResult premesse(int me_no, DateTime date_promis, decimal montant_promis)
        {

            var result = _context.DMecheances
                .Where(d => d.MeNo == me_no)
 
                .FirstOrDefault();
            result.MontantPromis = montant_promis;
            result.DatePromis = date_promis.Date;
            _context.SaveChanges();
            
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }

        }

        

        // DELETE: api/DMecheances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DMecheance>> DeleteDMecheance(int id)
        {
            var dMecheance = await _context.DMecheances.FindAsync(id);
            if (dMecheance == null)
            {
                return NotFound();
            }

            _context.DMecheances.Remove(dMecheance);
            await _context.SaveChangesAsync();

            return dMecheance;
        }

        private bool DMecheanceExists(int id)
        {
            return _context.DMecheances.Any(e => e.CbMarq == id);
        }
    }
}
