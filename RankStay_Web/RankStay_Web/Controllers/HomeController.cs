using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ProvinceModel _provinceModel = new();
        readonly PropertyModel _propertyModel = new();

        public async Task<IActionResult> Index()
        {
            return View(await _provinceModel.GetListProvinces());
        }

        [HttpGet("Home/Province/{provinceId}")]
        public async Task<IActionResult> Province(int provinceId)
        {
            return View(await _propertyModel.GetPropertiesByProvince(provinceId));
        }
    }
}