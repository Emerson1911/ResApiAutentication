using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ENAE20230901AutenticationCooki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotasController : ControllerBase
    {
        static List<object> data = new List<object>();
        // GET: api/<NotasController>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<object> Get()
        {
            return data;
        }


        // POST api/<NotasController>
        [HttpPost]
        public IActionResult Post(string nombre, int nota)
        {
            data.Add(new {nombre, nota});

            return Ok();
        }

       
    }
}
