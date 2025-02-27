﻿using Microsoft.AspNetCore.Mvc;
using stok_takip.Repositories;
using stok_takip.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace stok_takip.Controllers
{
    public class CategoryController : Controller
    {   
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index(string p)
        {   
           if(!string.IsNullOrEmpty(p))
            {
               return View(categoryRepository.List(x=>x.CategoryName==p));
            }
            return View(categoryRepository.TList());
        }


        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {   
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }


            categoryRepository.TAdd(p);

            return RedirectToAction("Index");
        }

        public IActionResult CategoryGet(int id) 
        {

            var x = categoryRepository.TGet(id);
            Category ct = new Category()
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                CategoryId = x.CategoryId
            };

            return View(ct);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var x = categoryRepository.TGet(p.CategoryId);
            x.CategoryName = p.CategoryName;
            x.Status = true;
            x.CategoryDescription = p.CategoryDescription;
            categoryRepository.TUpdate(x);

            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

    }
}
