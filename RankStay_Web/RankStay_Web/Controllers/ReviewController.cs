using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class ReviewController : Controller
    {
        readonly ReviewObj reviewObj = new();
        readonly ReviewModel reviewModel = new();
        List<ReviewObj> reviewlist = new List<ReviewObj>();

        //[FilterSessionValidation]
        [HttpGet]
        public IActionResult RegisterReview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterReview(ReviewObj reviewObj)
        {
            //propertyObj.PorpertyReviewComment = "Comment";
            //propertyObj.PorpertyReviewStar = 0.0;
            //propertyObj.PropetyDescription = "Description";
            //propertyObj.PropertyUserId = 1;

            if (reviewModel.RegisterReview(reviewObj) != string.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Reviews()
        {
            return View(reviewModel.GetListReviews());
        }
    }
}