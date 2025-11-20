using BasicASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.ViewComponents
{
    public class ProductFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ProductViewModel model)
        {
            // You can add logic here, like fetching categories from a database
            var categories = new List<string> { "Electronics", "Clothing", "Books", "Food", "Toys" };
            ViewBag.Categories = categories;
            
            return View(model ?? new ProductViewModel());
        }
    }
}
