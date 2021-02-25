using catalog_proyect.Data;
using catalog_proyect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog_proyect.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }
        //[Authorize]
        public IActionResult Index()
        {

            IEnumerable<Category> categories = _db.Category;
            return View(categories);
            
        }



        //[Authorize]
        //Get
        public IActionResult CreateCategory()
        {

            return View();
        }

        //[Authorize]
        //Post  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category category)
        {

            if (ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);

        }

        //[Authorize]
        public IActionResult EditCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Category category)
        {

            if (ModelState.IsValid)
            {
                _db.Category.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);

        }


        [Authorize]

        public IActionResult DeleteCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategoryPost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
