using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class ReviewController : Controller
    {
        readonly ReviewModel reviewModel = new();

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