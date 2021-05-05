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
    public class DNotificationsController : ControllerBase
    {
        private readonly dataRECOUVREMENTContext _context;

        public DNotificationsController(dataRECOUVREMENTContext context)
        {
            _context = context;
        }

        // GET: api/DNotifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DNotification>>> GetDNotification()
        {
            return await _context.DNotifications.ToListAsync();
        }

        // GET: api/DNotifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DNotification>> GetDNotification(string id)
        {
            var dNotification = await _context.DNotifications.FindAsync(id);

            if (dNotification == null)
            {
                return NotFound();
            }

            return dNotification;
        }

        //nbjour heki fel front date system - nb jour bech twalli egale date_echeance hedhe f  relance
        //nbjour heki fel front date system + nb jour bech twalli egale date_echeance hedhe f  prevenace

        // GET: api/DNotification/Get_NB_CL_Scenario_type/{NBJour}/{Type_Scenario}/{Type_Media}
        [HttpGet("Get_NB_CL_Scenario_type/{date}/{Type_Scenario}/{Type_Media}")]
        public ActionResult Get_NB_CL_Scenario_type(DateTime date,int Type_Scenario,int Type_Media )
        {



            var result = (_context.DNotifications
               
                .Include(d => d.NumScenarioNavigation)
                .Where(num => num.NumScenarioNavigation.Type == Type_Scenario && num.NumScenarioNavigation.Media == Type_Media && num.NumScenarioNavigation.Date.Date==date.Date)
                .Count()
                );

            return Ok(result);
        }
    
        // ok
            // GET: api/DNotification/GetNiveau_Releance/id
            [HttpGet("GetNiveau_Releance/{ct_num}")]
        public ActionResult Get_Niveau_Releance(string ct_num)
        {


         
            var result = (_context.DNotifications
                .Where(d => d.CtNum == ct_num)
                .Include(d => d.NumScenarioNavigation).Where(num => num.NumScenarioNavigation.Type== 2)
                .Select(d=>new
                {
                    d.NumScenarioNavigation.Date // 3lech mayraja3ech date m3a l count
                })
                .Count()
                );

             return Ok(result); 

        }
        // ok
        // GET: api/DNotification/GetNiveau_Releance/id
        [HttpGet("Getdate_Scenario/{ct_num}/{type_scenario}")]
        public ActionResult Get_date_scenario(string ct_num , int type_scenario)
        {
            //7achti be5er date ???
            var result = (_context.DNotifications
                .Where(d => d.CtNum == ct_num)
                .Include(d => d.NumScenarioNavigation).Where(num => num.NumScenarioNavigation.Type == type_scenario)
                .Select(d => new
                {
                    d.NumScenarioNavigation.Date
                }));
                

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

    


        // DELETE: api/DNotifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DNotification>> DeleteDNotification(string id)
        {
            var dNotification = await _context.DNotifications.FindAsync(id);
            if (dNotification == null)
            {
                return NotFound();
            }

            _context.DNotifications.Remove(dNotification);
            await _context.SaveChangesAsync();

            return dNotification;
        }

        private bool DNotificationExists(string id)
        {
            return _context.DNotifications.Any(e => e.CtNum == id);
        }
    }
}
