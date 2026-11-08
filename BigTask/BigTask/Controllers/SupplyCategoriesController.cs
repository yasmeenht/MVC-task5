using Microsoft.AspNetCore.Mvc;
using BigTask.Models;
using System.Text.Json;


namespace BigTask.Controllers
{
    public class SupplyCategoriesController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            SupplyCategories[] records =
            {
                new SupplyCategories("Graduation Certificates", "Supplier A", "Premium Certificate Package", 35, 2),
                new SupplyCategories("Graduation Certificates", "Supplier B", "Standard Certificate Package", 35, 1),
                new SupplyCategories("Graduation Certificates", "Supplier C", "Luxury Certificate Package", 35, 2),

                new SupplyCategories("Hospitality", "Supplier D", "Coffee & Drinks Package", 100, 2),
                new SupplyCategories("Hospitality", "Supplier E", "Sandwiches & Snacks Package", 100, 3),
                new SupplyCategories("Hospitality", "Supplier F", "Full Hospitality Package", 100, 4),

                new SupplyCategories("Graduation Gifts", "Supplier G", "Customized Mugs Package", 35, 2),
                new SupplyCategories("Graduation Gifts", "Supplier H", "Graduation Bags Package", 35, 3),
                new SupplyCategories("Graduation Gifts", "Supplier I", "Premium Gift Boxes Package", 35, 4)
            };
            HttpContext.Session.SetString("records", JsonSerializer.Serialize(records));
            ViewBag.Records = records;
            return View();
        }


        [HttpPost]
        public IActionResult Review(string Certificates, string Hospitality, string Gifts)
        {
            string[] SelectedRecords = {Certificates,  Hospitality, Gifts};
            HttpContext.Session.SetString("SelcectedRecords", JsonSerializer.Serialize(SelectedRecords));
            ViewBag.SelectedSuppliers = SelectedRecords;


            string? GetRecords = HttpContext.Session.GetString("records");
            List<SupplyCategories>? records = 
                JsonSerializer.Deserialize<List<SupplyCategories>>(GetRecords);
            ViewBag.Records = records;


            return View();
        }


        [HttpGet]
        public IActionResult Calculations()
        {
            string? saved = HttpContext.Session.GetString("selectedRecords");
            List<SupplyCategories> selectedRecords =
                JsonSerializer.Deserialize<List<SupplyCategories>>(saved!);

            double totalPrice = 0;
            List<double> offerTotals = new();

            foreach (SupplyCategories data in selectedRecords)
            {
                double offerTotal = data.UnitPrices * data.Quantity;
                offerTotals.Add(offerTotal);
                totalPrice += offerTotal;
            }

            double discount = 0;

            if (totalPrice > 500)
            {
                discount = 0.15;
            }
            else if (totalPrice > 300)
            {
                discount = 0.10;
            }

            double discountAmount = totalPrice * discount;
            double finalTotal = totalPrice - discountAmount;

            ViewBag.Records = selectedRecords;
            ViewBag.OfferTotals = offerTotals;
            ViewBag.Subtotal = totalPrice;
            ViewBag.DiscountPercentage = discount * 100;
            ViewBag.DiscountAmount = discountAmount;
            ViewBag.FinalTotal = finalTotal;

            return View();
        }
    }
}
