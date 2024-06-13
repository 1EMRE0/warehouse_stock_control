using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using stok_takip.Data;
using stok_takip.Data.Models;

namespace stok_takip.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(Prolist());
        }

        public List<Class1> Prolist()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname="Computer",
                stock = 150
            });
            cs.Add(new Class1()
            {
                proname = "Lcd",
                stock = 75
            });
            cs.Add(new Class1()
            {
                proname = "usb disk",
                stock = 200
            });
            return cs;
        }

        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult VisualizeProductResult2()
        {
            return Json(Foodlist());
        }

        public List<Class2> Foodlist()
        {
            List<Class2> cs2 = new List<Class2>();
            using(var c = new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stock,
                }).ToList();
                
            }
            return cs2;
        }

        public IActionResult Statistics()
        {
            return View();
        }
    }
}
