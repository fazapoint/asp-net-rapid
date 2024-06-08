using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    //Home/Index
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["FullName"] = "John Doe";
            ViewBag.Address = "Jl. Jend. Sudirman No. 1";

            Category model = new Category
            {
                CategoryId = 1,
                CategoryName = "Laptop Gaming"
            };

            return View(model);
        }

        public IActionResult Details(string firstname, string lastname)
        {
            return Content($"Hello {firstname} {lastname}");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
