using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ProvinceModel provinceModel = new();
        readonly PropertyModel propertyModel = new();

        public async Task<IActionResult> Index()
        {
            return View(await provinceModel.GetListProvinces());
        }

        [HttpGet("Home/Province/{provinceId}")]
        public async Task<IActionResult> Province(int provinceId)
        {
            try
            {
                return View(await propertyModel.GetPropertiesByProvince(provinceId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching provinces: " + ex.Message);
            }
        }
    }
}