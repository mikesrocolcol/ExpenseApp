using ExpenseManagement.Data;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseManagement.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseDbContext _db;

        public ExpenseController(ExpenseDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseEntity> categoriesList = _db.Categories.ToList();
            foreach (var obj in categoriesList)
            {
                obj.ExpenseCategory = _db.ExpenseCategory.FirstOrDefault
                    (u => u.ExpenseCategoryId == obj.ExpenseCategoryId);
            }
            return View(categoriesList);
        }



        //GET
        public IActionResult Create(ExpenseEntity obj)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList =
                _db.ExpenseCategory.Select(i => new SelectListItem
                {
                    Text = i.ExpenseCategoryName,
                    Value = i.ExpenseCategoryId.ToString(),
                });
            ViewBag.PopulateExpCategory = getExpenseCategoryList;
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
        //POST


        //GET

        public IActionResult Edit(int? id)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList =
               _db.ExpenseCategory.Select(i => new SelectListItem
               {
                   Text = i.ExpenseCategoryName,
                   Value = i.ExpenseCategoryId.ToString(),
               });
            ViewBag.PopulateExpCategory = getExpenseCategoryList;


            var categoryFromDb = _db.Categories.Find(id);


            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST

        [HttpPost]
        public IActionResult Edit(ExpenseEntity obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //DELETE
        public IActionResult Delete(int? id)
        {

            IEnumerable<SelectListItem> getExpenseCategoryList =
               _db.ExpenseCategory.Select(i => new SelectListItem
               {
                   Text = i.ExpenseCategoryName,
                   Value = i.ExpenseCategoryId.ToString(),
               });
            ViewBag.PopulateExpCategory = getExpenseCategoryList;
            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST
        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {


            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

    }

}

