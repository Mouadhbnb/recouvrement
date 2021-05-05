using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GESTIONDERECOUVREMENT.Models;
using System.Collections;

namespace GESTIONDERECOUVREMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DComptetsController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DComptetsController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

       

   
       // ok
        // GET: api/DComptets/Fiche_Client/id
         [HttpGet("GetInfo_Client/{id}")]
         public ActionResult GetInfo_Client(string id)
         {


             var dComptett = (_context.DComptets
                 .Where(d => d.CtNum == id)
                 .Include(d => d.CtRecouvreurNavigation)
                 .Include(d => d.DMecheances)
                 .Include(d =>d.DDocentetes )
                 .Select(d => new
                 {
                     d.CtNum,
                     d.CtIntitule,
                     d.CtContact,
                     d.CtEmail,
                     d.CtAdresse,
                     d.CtTelephoneFix,
                     d.CtTelephonePoste,
                     d.CtTelephone,
                     d.CtVille,
                     d.CtCodeRegion,
                     d.CtPays,
                     d.CtCodePostal,
                     d.CtProfile,
                     nom_recouvreur = d.CtRecouvreurNavigation.EmNom,
                     prenom_recouvreur = d.CtRecouvreurNavigation.EmPrenom,
                     montant_date_promis = d.DMecheances.Select(y=> new {y.MeNo, y.DatePromis, y.MontantPromis }),
                     date_echeance_modereglement = d.DMecheances.Select(dt=>new { dt.MeDatePrevu, dt.MeModeReglement}),
                     // hedhe bech fel front namal boucle lin nal9a awal date akbar m date system heki date prochaine echeance w ne5ou e5er date ta3 echeance ta3 facture
                    situatoion_du_compt=d.DDocentetes.Select(f => new { f.DoPiece, f.DoDate,f.DoTotalTtc} )
                 }
                 ));

             if (dComptett == null)
             {
                 return NotFound();
             }
             else { return Ok(dComptett); }

         }

         

       
        private bool DComptetExists(string id)
        {
            return _context.DComptets.Any(e => e.CtNum == id);
        }
    }
}
