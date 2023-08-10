using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class ProvinceController : Controller
    {
        readonly ProvinceModel provinceModel = new();

        [HttpGet]
        public IActionResult Provinces()
        {
            return View(provinceModel.GetListProvinces());
        }
    }
}