using Microsoft.AspNetCore.Mvc;
using projectWeb.Data;
using projectWeb.Models;

namespace projectWeb.Controllers
{
    public class categoryController1 : Controller
    {
        private readonly ApplicationDbContext _db;

        public categoryController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> abjCategoryList = _db.Categories;
            return View(abjCategoryList);
        }
        //Get
        public IActionResult Create()
        {
            
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created successfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit( int ?id)
        {
            if(id==null ||id==0)
            { return NotFound(); }

            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDb =_db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDb2 =_db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated successfuly";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            { return NotFound(); }

            var categoryFromDb = _db.Categories.Find(id);
            
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj= _db.Categories.Find(id);
            if(obj == null)
            { return NotFound(); }
            
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted successfuly";

            return RedirectToAction("Index");
            
            
        }
    }
}
