using BasicASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.ViewComponents
{
    public class AddressFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(AddressViewModel model, string prefix = "")
        {
            ViewData["Prefix"] = prefix;
            return View(model ?? new AddressViewModel());
        }
    }
}
