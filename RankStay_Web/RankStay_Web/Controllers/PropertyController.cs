using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class PropertyController : Controller
    {
        readonly PropertyModel propertyModel = new();
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
            //propertyObj.PorpertyReviewComment = "Comment";
            //propertyObj.PorpertyReviewStar = 0.0;
            //propertyObj.PropetyDescription = "Description";
            //propertyObj.PropertyUserId = 1;

            if (propertyModel.RegisterProperty(propertyObj) != string.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Property()
        {
            return View(reviewModel.GetListReviews());
        }

        // similar, pero que reciba id
    }
}