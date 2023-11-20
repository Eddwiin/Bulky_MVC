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
    }
}
