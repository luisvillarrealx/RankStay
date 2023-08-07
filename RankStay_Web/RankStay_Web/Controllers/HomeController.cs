using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class HomeController : Controller
    {
        public ProvinceModel provinceModel = new();
        List<ProvinceObj> provincelist = new List<ProvinceObj>();

        //readonly PropertyObj propertyObj = new();
        PropertyModel propertyModel = new();
        List<PropertyObj> propertieslist = new List<PropertyObj>();

        public IActionResult Index()
        {
            provincelist = provinceModel.GetListProvinces().ToList();
            return View(provincelist);
        }

        public IActionResult Province()
        {
            propertieslist = propertyModel.getListProperties();
            return View(propertieslist);
        }

    }
}
