using Bulky_MVC.Data;
using Bulky_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext dbContext) {
            _db = dbContext;
        }
        
        public IActionResult Index()
        {
            List<Category> objCategories = _db.Categories.ToList();

            return View(objCategories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
            }
   
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null ||  id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null) {
                return NotFound();
            }


            return View();
        }

        [HttpPut]
        public IActionResult Edit(Category obj)
        {
            return View(obj);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
