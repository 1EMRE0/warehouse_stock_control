using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using stok_takip.Data.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace stok_takip.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }

            var datavalue = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.UserName)
                };

                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return Redirect("/Category/Index");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(p);
        }
    }
}
