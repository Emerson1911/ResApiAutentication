using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ENAE20230901AutenticationCooki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(string login, string password)
        {
            if(login == "Emerson" && password == "Aguilar")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,login),
                };

                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {

                };
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return Ok("cuidame bien que lo mio es serio, que siempre me pierdo, quiero que estes, a mi lado otra vez");
            }
            else
            {
                return Unauthorized("Tengo reloj tengo reloj nuevo jeeee....");
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout() { 
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok("Perdiste reloj por lento..");
        }
    }
}
