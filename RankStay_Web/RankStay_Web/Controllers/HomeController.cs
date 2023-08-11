using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ProvinceModel provinceModel = new();
        readonly PropertyModel propertyModel = new();

        public IActionResult Index()
        {
            return View(provinceModel.GetListProvinces().ToList());
        }

        [HttpGet("Home/Province/{provinceId}")]
        public async Task<IActionResult> Province(int provinceId)
        {
            try
            {
                var reviews = await propertyModel.GetPropertiesByProvince(provinceId);
                return View(reviews);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                return StatusCode(500, "An error occurred while fetching reviews: " + ex.Message);
            }
        }
    }
}