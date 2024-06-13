using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using stok_takip.Data.Models;
using stok_takip.Repositories;
using X.PagedList;

namespace stok_takip.Controllers
{
    public class FoodController : Controller
    {    FoodRepository foodRepository = new FoodRepository();   

        Context c = new Context();
        public IActionResult Index(int page=1)
        {   
           
            return View(foodRepository.TList("Category").ToPagedList(page,3));
        }

        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> Values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()

                   

                                           }).ToList();
            ViewBag.v1=Values;
            
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(urunekle p)
        {   Food f = new Food();
            if(p.ImageUrl != null)
            {
                var extension=Path.GetExtension(p.ImageUrl.FileName);
                var newimagename=Guid.NewGuid()+extension;
                var location=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/resimler/",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);
                f.ImageUrl=newimagename;
            }
            f.Name= p.Name;
            f.Price = p.Price;
            f.Stock= p.Stock;
            f.CategoryId= p.CategoryId;
            f.Description= p.Description;
            foodRepository.TAdd(f);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteFood(int id)
        {
            foodRepository.TDelete(new Food {FoodId=id } );
            return RedirectToAction("Index");
        }

        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);
            List<SelectListItem> Values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryId.ToString()



                                           }).ToList();
            ViewBag.v1 = Values;
            Food f = new Food()
            {   FoodId=x.FoodId,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            };
            return View(f);
        }

        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodRepository.TGet(p.FoodId);
            x.Name = p.Name;
            x.Price = p.Price;
            x.Description = p.Description;
            x.ImageUrl = p.ImageUrl;
            x.Stock = p.Stock;
            x.CategoryId = p.CategoryId;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
