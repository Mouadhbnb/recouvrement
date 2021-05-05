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
    public class DLitigesController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DLitigesController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DLitiges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DLitige>>> GetDLitige()
        {
            return await _context.DLitiges.ToListAsync();
        }


        //add client into list of litige
        [HttpGet("Post_Client_Litige/{ct_num}")]
        public ActionResult PostClient_Litige(string ct_num)
        {
            var dcomptet = _context.DComptets
                .Where(d => d.CtNum == ct_num);
            var dlitige = new DLitige();
            dlitige.Date = DateTime.Today.Date;
            dlitige.CtNum = ct_num;

            _context.DLitiges.Add(dlitige);
            _context.SaveChanges();
            var result = (_context.DLitiges
                .Include(d => d.CtNumNavigation).Where(d=>d.CtNum==ct_num)
                .Select(d => new
                {
                    d.CodeLitige,
                    d.CtNum,
                    d.Date,
                    d.CtNumNavigation.CtIntitule,
                    // niveau de relance applée dans le front {id}
                    //montant qui rest aussi appelée
                    //somme total calculer dans le front
                }
                ));

            if (result == null)
            {
                return NotFound();
            }
            else { return Ok(result); }

        }

        // GET: api/DLitiges/5
        [HttpGet("Client_Litige")]
        public ActionResult GetClient_Litige()
        {
            var result = (_context.DLitiges
                .Include(d => d.CtNumNavigation)
                .Select(d => new
                {   d.CtNum,
                    d.CtNumNavigation.CtIntitule,
                   // niveau de relance applée dans le front {id}
                   //montant qui rest aussi appelée
                   //somme total calculer dans le front
                }
                ));

            if (result == null)
            {
                return NotFound();
            }
            else { return Ok(result); }

        }

        // GET: api/DLitiges/5

        [HttpGet("{id}")]
        public async Task<ActionResult<DLitige>> GetDLitige(string id)
        {
            var dLitige = await _context.DLitiges.FindAsync(id);

            if (dLitige == null)
            {
                return NotFound();
            }

            return dLitige;
        }

      


        // DELETE: api/DLitiges/5
        [HttpDelete("{ct_num}")]
        public async Task<ActionResult<DLitige>> DeleteDLitige(string ct_num)
        {
            var dLitige = await _context.DLitiges.Where(d=>d.CtNum==ct_num).FirstOrDefaultAsync();
            if (dLitige == null)
            {
                return NotFound();
            }

            _context.DLitiges.Remove(dLitige);
            await _context.SaveChangesAsync();

            return dLitige;
        }

        private bool DLitigeExists(int id)
        {
            return _context.DLitiges.Any(e => e.CodeLitige == id);
        }
    }
}
