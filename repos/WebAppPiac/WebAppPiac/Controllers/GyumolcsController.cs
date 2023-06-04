using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPiac.Data;
using WebAppPiac.Models;

namespace WebAppPiac.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GyumolcsController : ControllerBase
    {




        [HttpGet]

        public IActionResult Get()
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                try
                {
                    List<Gyumolcs> gyumolcsok = new List<Gyumolcs>(context.Gyumolcs.ToList());
                    return Ok(gyumolcsok);
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }

    }
}
