using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.WebApplication.DAL;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategory _categoryDal;
        public CategoriesController(ICategory categoryDal)
        {
            _categoryDal = categoryDal;
        }

        // GET: CategoriesController
        public ActionResult Index(string categoryname= "")
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            IEnumerable<Category> categories;
            if (categoryname != "")
            {
                categories = _categoryDal.GetCategoriesByName(categoryname);
            }
            else
            {
                categories = _categoryDal.GetAll();
            }
            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categoryDal.GetById(id);
            return View(category);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                var result = _categoryDal.Add(category);

                TempData["Message"] = $"{category.CategoryName} added succesfully";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Category not added";
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryDal.GetById(id);
            return View(category);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                var result = _categoryDal.Update(category);

                TempData["Message"] = $"Category {category.CategoryName} update succesfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Category not updated";
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categoryDal.GetById(id);
            return View(category);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int CategoryId)
        {
            try
            {
                _categoryDal.Delete(CategoryId);
                TempData["Message"] = $"Category with id:{CategoryId} deleted succesfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Category not deleted";
                return View();
            }
        }
    }
}
