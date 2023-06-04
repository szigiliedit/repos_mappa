using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Piac.Models;

namespace Piac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GyumolcsController : ControllerBase
    {
        [HttpGet]
        [Route("GetGyumolcsok")]

        public IActionResult GetGyumolcsok()
        {
            using(var context=new piacContext())
            {
                try
                {
                    return StatusCode(200,context.Gyumolcsoks.ToList());
                }
                catch (Exception ex)
                {
                    /*List<Gyumolcsok> hiba = new List<Gyumolcsok>();
                    Gyumolcsok gyumolcs = new Gyumolcsok();
                    gyumolcs.Nev = ex.Message;
                    hiba.Add(gyumolcs);*/
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost]
        [Route("PostGyumolcs")]

        public IActionResult PostGyumolcs(Gyumolcsok gyumolcs)
        {
            using (piacContext context=new piacContext())
            {
                try
                {
                    context.Gyumolcsoks.Add(gyumolcs);
                    context.SaveChanges();
                    return StatusCode(201,"A gyümölcs hozzáadása sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        [Route("PutGyumolcs")]

        public string PutGyumolcs(Gyumolcsok gyumolcs)
        {
            using (piacContext context = new piacContext())
            {
                try
                {
                    context.Gyumolcsoks.Update(gyumolcs);
                    context.SaveChanges();
                    return $"A(z) {gyumolcs.Nev} gyümölcs módosítása sikeresen megtörtént.";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        [HttpDelete]
        [Route("DeleteGyumolcs")]

        public string DeleteGyumolcs(int Id)
        {
            using (piacContext context = new piacContext())
            {
                try
                {
                    Gyumolcsok gyumolcs = new Gyumolcsok();
                    gyumolcs.Id = Id;
                    context.Gyumolcsoks.Remove(gyumolcs);
                    context.SaveChanges();
                    return $"A(z) {Id}. azonosítóval rendelkező gyümölcs törlése sikeresen megtörtént.";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
