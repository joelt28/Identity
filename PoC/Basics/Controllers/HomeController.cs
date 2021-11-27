using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Basics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "Claim.DoB")]
        public IActionResult SecretPolicy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult SecretRole()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var grandmaClaims = new List<Claim>() 
            { 
                new Claim(ClaimTypes.Name,"Bob"),
                new Claim(ClaimTypes.Email, "bob@fmail.com"),
                 new Claim(ClaimTypes.DateOfBirth, "11/11/2000"),
                 new Claim(ClaimTypes.Role, "Admin"),
                new Claim("CustomClaims","Very Nice Boi")
            };
            var licenseClaims = new List<Claim>()
            { 
                new Claim(ClaimTypes.Name, "Bob K Foo"),
                new Claim("DrivingLicense","A+")
            };
            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandmas Identity");
            var licenseIdentiy = new ClaimsIdentity(licenseClaims, "Government");

            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentiy });
            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}
