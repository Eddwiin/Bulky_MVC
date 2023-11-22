using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo) {
            _categoryRepo = categoryRepo;
        }
        
        public IActionResult Index()
        {
            List<Category> objCategories = _categoryRepo.GetAll().ToList();

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
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
            }
   
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null ||  id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _categoryRepo.Get(c => c.Id == id);

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
