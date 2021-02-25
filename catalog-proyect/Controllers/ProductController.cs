using catalog_proyect.Data;
using catalog_proyect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog_proyect.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            CatalogFrontData viewData = new CatalogFrontData();
            viewData.categories =  _db.Category;
            viewData.products = _db.Product;
            return View(viewData);
        }

        //Get
        public IActionResult CreateProduct()
        {

            //IEnumerable<Category> categories = _db.Category;
            ViewBag.Types = new SelectList(_db.Category.ToList(), "id", "name", "0");
            return View();
        }

        //Post  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                product.creationDate = DateTime.Now;
                _db.Product.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);

        }


        public IActionResult EditProduct(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Product.Find(id);

            if(obj == null)
            {
                return NotFound();
            }
            ViewBag.Types = new SelectList(_db.Category.ToList(), "id", "name", "0");
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                _db.Product.Update(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);

        }




        public IActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Product.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            ViewBag.Types = new SelectList(_db.Category.ToList(), "id", "name", "0");
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProductPost(int? id)
        {
            var obj = _db.Product.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Product.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
