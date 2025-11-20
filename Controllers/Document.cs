using Microsoft.AspNetCore.Mvc;

namespace BasicASP.Controllers
{
    public class Document : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
