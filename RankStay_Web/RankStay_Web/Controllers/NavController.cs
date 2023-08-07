using Microsoft.AspNetCore.Mvc;

namespace RankStay_Web.Controllers
{
    public class NavController : Controller
    {
        public IActionResult About()
        {
            return PartialView("_Part_About");
        }

        public IActionResult Services()
        {
            return PartialView("_Part_Service");
        }

        public IActionResult Projects()
        {
            return PartialView("_Part_Project");
        }
    }
}
