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
                        //return Ok(Program.CreateSHA256("a" + felhasznalo[0].Salt));
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
                    if (felhasznalo.Count > 0 && felhasznalo[0].Aktiv==1)
                    {
                        //Egyszerre csak egy gépről dolgozhat ha ez a rész benne marad
                        bool talalat = false;
                        int index = 0;
                        int elemSzam = Program.LoggedInUsers.Count;
                        while(!talalat && index<elemSzam)
                        {
                            if (Program.LoggedInUsers.ElementAt(index).Value.FelhasznaloNeve==nev)
                            {
                                lock(Program.LoggedInUsers)
                                {
                                    Program.LoggedInUsers.Remove(Program.LoggedInUsers.ElementAt(index).Key);
                                }
                                talalat = true;
                            }
                            index++;
                        }
                        //Egyfelhasználós vége
                        if (Program.CreateSHA256(tmpHash) == felhasznalo[0].Hash)
                        {
                            string token=Guid.NewGuid().ToString();
                            lock(Program.LoggedInUsers)
                            {
                                Program.LoggedInUsers.Add(token, felhasznalo[0]);
                            }
                            string[] response = new string[3] { token, felhasznalo[0].TeljesNev, felhasznalo[0].Jogusultsag.ToString() };
                            return Ok(response);
                        }
                        else
                        {
                            string[] response = new string[3] { "Hibás jelszó!", "", "" };
                            return Ok(response);
                        }
                    }
                    else
                    {
                        string[] response = new string[3] { "Hibás felhasználói név!/Inaktív felhasználó.", "", "" };
                        return Ok(response);
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
