using BasicASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Create()
        {
            return View(new PersonViewModel { PersonType = "Student" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the form data here
                var typeInfo = model.PersonType switch
                {
                    "Student" => $"Student ID: {model.StudentId}",
                    "Employee" => $"Company: {model.Company}, Job: {model.JobTitle}",
                    _ => "General Person"
                };
                
                TempData["SuccessMessage"] = $"{model.PersonType} {model.Name} created successfully! {typeInfo}";
                return RedirectToAction(nameof(Success));
            }

            // If validation fails, return the view with the model
            return View(model);
        }

        public IActionResult GetPersonFormComponent(string personType)
        {
            var model = new PersonViewModel { PersonType = personType };
            
            return personType switch
            {
                "Student" => ViewComponent("StudentForm", model),
                "Employee" => ViewComponent("EmployeeForm", model),
                _ => ViewComponent("PersonForm", model)
            };
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
