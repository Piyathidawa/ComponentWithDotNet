using BasicASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the customer data here
                TempData["SuccessMessage"] = $"Customer {model.FirstName} {model.LastName} created successfully!";
                return RedirectToAction(nameof(Success));
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
