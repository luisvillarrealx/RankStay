using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Entities;
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
        
        [HttpGet]
        public IActionResult RegisterProvince()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterProvince(ProvinceObj provinceObj)
        {
            return _provinceModel.RegisterProvince(provinceObj) != null 
                ? RedirectToAction("Index", "Home") : View();
        }

        [HttpGet("Province/EditProvince/{provinceId}")]
        public async Task<IActionResult> EditProvince(int provinceId)
        {
            return View(await _provinceModel.GetProvince(provinceId));
        }


        [HttpPost]
        public ActionResult EditProvince(ProvinceObj provinceObj)
        {
            provinceObj.ProvinceId = 0;
            provinceObj.ProvinceName = "Alajuela";
            provinceObj.ProvinceDescription = "Conocida por sus hermosos paisajes y el Aeropuerto Internacional Juan Santamaría.";
            return _provinceModel.PutProvince(provinceObj) != null
                ? RedirectToAction("Provinces","Province"): View();
        }
    }
}