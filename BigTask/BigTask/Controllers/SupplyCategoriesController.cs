using BigTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace BigTask.Controllers
{
    public class SupplyCategoriesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
       
            return View();
        }

        [HttpPost]
        public IActionResult ShowSuppliers(string SelectedCategory)
        {
            SupplyCategories[] categories =
            {
                new SupplyCategories("Graduation Certificates", "Supplier A", "Premium Certificate Package"),
                new SupplyCategories("Graduation Certificates", "Supplier B", "Standard Certificate Package"),
                new SupplyCategories("Graduation Certificates", "Supplier C", "Luxury Certificate Package"),

                new SupplyCategories("Hospitality", "Supplier D", "Coffee & Drinks Package"),
                new SupplyCategories("Hospitality", "Supplier E", "Sandwiches & Snacks Package"),
                new SupplyCategories("Hospitality", "Supplier F", "Full Hospitality Package"),

                new SupplyCategories("Graduation Gifts", "Supplier G", "Customized Mugs Package"),
                new SupplyCategories("Graduation Gifts", "Supplier H", "Graduation Bags Package"),
                new SupplyCategories("Graduation Gifts", "Supplier I", "Premium Gift Boxes Package")
            };
            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = SelectedCategory;
            return View();
        }

       
    }
}
