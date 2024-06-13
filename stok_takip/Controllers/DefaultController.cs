using Microsoft.AspNetCore.Mvc;

namespace stok_takip.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryDetails()
        {
            return View();
        }

	}
}
