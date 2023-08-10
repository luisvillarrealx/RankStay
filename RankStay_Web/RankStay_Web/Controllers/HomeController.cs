using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class HomeController : Controller
    {
        //readonly PropertyObj propertyObj = new();
        public ProvinceModel provinceModel = new();
        readonly PropertyModel propertyModel = new();

        public IActionResult Index()
        {
            return View(provinceModel.GetListProvinces().ToList());
        }

        public IActionResult Province()
        {
            return View(propertyModel.getListProperties());
        }

    }
}