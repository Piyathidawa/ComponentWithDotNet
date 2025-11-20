using BasicASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the product data here
                TempData["SuccessMessage"] = $"Product '{model.Name}' created successfully with price ${model.Price}!";
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
