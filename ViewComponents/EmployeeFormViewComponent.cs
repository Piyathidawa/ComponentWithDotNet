using BasicASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.ViewComponents
{
    public class EmployeeFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PersonViewModel model)
        {
            return View(model ?? new PersonViewModel());
        }
    }
}
