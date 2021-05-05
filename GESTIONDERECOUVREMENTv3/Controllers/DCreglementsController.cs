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
    public class DCreglementsController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DCreglementsController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DCreglements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCreglement>>> GetDCreglement()
        {
            return await _context.DCreglements.ToListAsync();
        }

        // GET: api/DCreglements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCreglement>> GetDCreglement(int id)
        {
            var dCreglement = await _context.DCreglements.FindAsync(id);

            if (dCreglement == null)
            {
                return NotFound();
            }

            return dCreglement;
        }

        //ok
       // GET: api/DCreglement/Gettotalpaye
        [HttpGet("GetTotal_Paye_ParModePaiement/{N_Reglement}")]
        public decimal GetTotal_Paye_ParModePaiement(int N_Reglement)
        {
            var result = _context.DCreglements
                .Where( d => d.NReglement== N_Reglement)
                .Select(d => new
                {
                    d.RgMontant
                }
                ).ToList();
            decimal x = 0;
            foreach (var o in result)
            {

                x = Decimal.Add(x, (decimal)o.RgMontant);
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
        [HttpGet("EncaissementParClient/{CT_Num}")]
        public ActionResult EncaissementParClient(string CT_Num)
        {

            var result = _context.DCreglements.Where(d => d.CtNumPayeur==CT_Num)
                .Select(d => new
                {
                    d.CtNumPayeur,
                    d.CbModification,
                    d.NReglement,
                    d.RgMontant
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

        private bool DCreglementExists(int id)
        {
            return _context.DCreglements.Any(e => e.RgNo == id);
        }
    }
}
