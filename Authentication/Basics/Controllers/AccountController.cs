using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Authenticate()
        {
            var claims1 = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Alex"),
                new Claim(ClaimTypes.Email, "twistorapp@gmail.com"),
                new Claim(ClaimTypes.Role, "admin"),
                new Claim("customClaim", "customValue")
            };

            var licenseClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Alex Alsina"),
                new Claim("Driver.Level", "Top")
            };

            var identity1 = new ClaimsIdentity(claims1, "Authority 1");
            var identityLicense = new ClaimsIdentity(licenseClaims, "DriverLicense");

            var principal = new ClaimsPrincipal(new[] { identity1, identityLicense });

            HttpContext.SignInAsync(principal);

            return LocalRedirect("/home/index");
        }
    }
}
