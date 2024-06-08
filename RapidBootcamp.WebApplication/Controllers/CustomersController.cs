using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.WebApplication.DAL;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomer _customerDal;
        // CONSTRUCTOR
        public CustomersController(ICustomer customerDal)
        {
            _customerDal = customerDal;
        }

        // GET: CustomersController
        public ActionResult Index(string customername = "")
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            IEnumerable<Customer> customers;
            if (customername != "")
            {
                customers = _customerDal.GetCustomersByName(customername);
            }
            else
            {
                customers = _customerDal.GetAll();
            }

            return View(customers);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var result = _customerDal.GetById(id);
            return View(result);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var result = _customerDal.Add(customer);
                TempData["Message"] = $"{customer.CustomerName} added as a customer";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Failed to add customer";
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _customerDal.GetById(id);
            return View(result);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                var result = _customerDal.Update(customer);
                TempData["Message"] = $"Customer {customer.CustomerName} update succesfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Customer not updated";
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerDal.GetById(id);
            return View(customer);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int CustomerId)
        {
            try
            {
                _customerDal.Delete(CustomerId);
                TempData["Message"] = $"Customer with id:{CustomerId} deleted succesfully";
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
