using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Szigili_Edit_backend.Models;

namespace Szigili_Edit_backend.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class VersenyzoController : ControllerBase
    {
        private readonly uszoebContext context = new();

        [HttpGet]

        public IActionResult GetVersenyzoNev(string nev)
        {
            try
            {
                Versenyzok versenyzo = context.Versenyzoks
                    .Include(versenyzo => versenyzo.Szamoks)
                    .Include(versenyzo => versenyzo.Orszag)
                    .First(versenyzo => versenyzo.Nev == nev);

                return StatusCode(200, versenyzo);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.ToString());
            }
        }

        [HttpGet]
        public IActionResult GetVersenyzokSzama()
        {
            try
            {
                int versenyzokSzama = context.Versenyzoks.Count();
                return StatusCode(200, versenyzokSzama);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.ToString());                
            }
        }

        private string userId = "FEB3F4FEA09CE43E";

        [HttpPost]
        public IActionResult AddVersenyzo(VersenyzoDto ujVersenyzo, [FromQuery] string userID)
        {
            if (userId != userID)
            {
                return StatusCode(401, "Nincs jogosultsága új versenyző felvételéhez!");
            }

            try
            {
                Versenyzok versenyzo = new()
                {
                    Id = ujVersenyzo.id,
                    Nev = ujVersenyzo.nev,
                    OrszagId = ujVersenyzo.orszagId,
                    Nem = ujVersenyzo.nem
                };

                context.Versenyzoks.Add(versenyzo);
                context.SaveChanges();

                return StatusCode(201, "Versenyző hozzáadása sikeresen megtörtént.");
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.ToString()); ;
            }
        }

        [HttpPut]

        public IActionResult UpdateVersenyzo(VersenyzoDto modositottVersenyzo, [FromQuery] string userID)
        {

            if (userId != userID)
            {
                return StatusCode(401, "Nincs jogosultsága a versenyzők módosításához!");
            }

            try
            {
                Versenyzok versenyzo = context.Versenyzoks
                    .First(versenyzo => versenyzo.Id == modositottVersenyzo.id);

                versenyzo.Nev = modositottVersenyzo.nev;
                versenyzo.OrszagId = modositottVersenyzo.orszagId;
                versenyzo.Nem = modositottVersenyzo.nem;

                context.Update(versenyzo);
                context.SaveChanges();

                return StatusCode(200, "Versenyző adatainak a módosítása sikeresen megtörtént.");

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.ToString()); ;
            }
        }

        [HttpDelete]

        public IActionResult DeleteVersenyzo(VersenyzoDto torlendoVersenyzo, [FromQuery] string userID)
        {

            if (userId != userID)
            {
                return StatusCode(401, "Nincs jogosultsága a versenyzők adatainak törléséhez!");
            }

            try
            {
                Versenyzok versenyzo = context.Versenyzoks
                   .First(versenyzo => versenyzo.Id == torlendoVersenyzo.id);
               
                context.Remove(versenyzo);
                context.SaveChanges();
                return StatusCode(201, "Versenyző adatainak a törlése sikeresen megtörtént.");
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.ToString()); ;
            }
        }
    }
}
