using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class ProvinceController : Controller
    {
        readonly ProvinceModel _provinceModel = new();

        [HttpGet]
        public async Task<IActionResult> Provinces()
            {
            return View(await _provinceModel.GetListProvinces());
        }
    }
}