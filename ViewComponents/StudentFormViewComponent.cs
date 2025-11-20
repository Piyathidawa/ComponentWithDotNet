using BasicASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.ViewComponents
{
    public class StudentFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PersonViewModel model)
        {
            return View(model ?? new PersonViewModel());
        }
    }
}
