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
            // Log received data in C# backend
            Console.WriteLine("=== DATA RECEIVED IN C# BACKEND ===");
            Console.WriteLine($"PersonType: {model.PersonType}");
            Console.WriteLine($"Name: {model.Name}");
            Console.WriteLine($"Email: {model.Email}");
            Console.WriteLine($"Age: {model.Age}");
            Console.WriteLine($"StudentId: {model.StudentId}");
            Console.WriteLine($"Company: {model.Company}");
            Console.WriteLine($"JobTitle: {model.JobTitle}");
            Console.WriteLine($"Contract Persons Count: {model.ContractPersons?.Count ?? 0}");
            
            if (model.ContractPersons != null && model.ContractPersons.Any())
            {
                Console.WriteLine("\n=== CONTRACT PERSONS LIST ===");
                foreach (var person in model.ContractPersons)
                {
                    Console.WriteLine($"  Person: {person.FirstName} {person.LastName}");
                    Console.WriteLine($"    Age: {person.Age}");
                    Console.WriteLine($"    Position: {person.Position ?? "N/A"}");
                    Console.WriteLine($"    Notes: {person.Notes ?? "N/A"}");
                    Console.WriteLine("  ---");
                }
            }
            Console.WriteLine("===================================");

            if (ModelState.IsValid)
            {
                // Process the form data here
                var typeInfo = model.PersonType switch
                {
                    "Student" => $"Student ID: {model.StudentId}",
                    "Employee" => $"Company: {model.Company}, Job: {model.JobTitle}",
                    _ => "General Person"
                };
                
                var personsInfo = model.ContractPersons != null && model.ContractPersons.Any() 
                    ? $" with {model.ContractPersons.Count} contract person(s)" 
                    : "";
                
                Console.WriteLine($"✓ Validation passed. Creating {model.PersonType}: {model.Name}{personsInfo}");
                
                TempData["SuccessMessage"] = $"{model.PersonType} {model.Name} created successfully! {typeInfo}{personsInfo}";
                TempData["ContractPersonsCount"] = model.ContractPersons?.Count ?? 0;
                
                return RedirectToAction(nameof(Success));
            }

            // If validation fails, return the view with the model
            Console.WriteLine("✗ Validation failed:");
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"  - {error.ErrorMessage}");
            }
            
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
