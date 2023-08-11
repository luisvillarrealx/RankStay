using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class PropertyController : Controller
    {
        readonly PropertyModel _propertyModel = new();
        readonly ReviewModel reviewModel = new();

        //[FilterSessionValidation]
        [HttpGet]
        public IActionResult RegisterProperty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterProperty(PropertyObj propertyObj)
        {
            //propertyObj.propertyProvinceId = 1;
            //propertyObj.propertyName = "Prueba";

            if (_propertyModel.RegisterProperty(propertyObj) != string.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet("Property/Property/{propertyId}")]
        public async Task<IActionResult> Property(int propertyId)
        {
            try
            {
                var reviews = await reviewModel.GetReviewsByProperty(propertyId);
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