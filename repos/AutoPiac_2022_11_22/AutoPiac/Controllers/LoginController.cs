using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoPiac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace AutoPiac.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("SaltRequest/{nev}")]

        public IActionResult SaltRequest(string nev)
        {
            using (autopiacContext context=new autopiacContext())
            {
                try
                {
                    List<Felhasznalo> felhasznalo = context.Felhasznalos.Where(f => f.FelhasznaloNeve==nev).ToList();
                    if (felhasznalo.Count>0)
                    {
                        //string salt = Program.GenerateSalt();
                        //string hash = Program.CreateSHA256(Program.CreateSHA256("a" + felhasznalo[0].Salt));
                        return Ok(Program.CreateSHA256("a" + felhasznalo[0].Salt));
                        return Ok(felhasznalo[0].Salt);
                    }
                    else
                    {
                        return BadRequest("Nincs ilyen nevű felhasználó!");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost]

        public IActionResult Login(string nev,string tmpHash)
        {
            using(autopiacContext context=new autopiacContext())
            {
                try
                {
                    List<Felhasznalo> felhasznalo = context.Felhasznalos.Where(f => f.FelhasznaloNeve == nev).ToList();
                    if (felhasznalo.Count > 0)
                    {
                        if (Program.CreateSHA256(tmpHash) == felhasznalo[0].Hash)
                        {
                            return Ok("Sikeres bejelentkezés.");
                        }
                        else
                        {
                            return BadRequest("Hibás jelszó!");
                        }
                    }
                    else
                    {
                        return BadRequest("Hibás felhasználói név!");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
