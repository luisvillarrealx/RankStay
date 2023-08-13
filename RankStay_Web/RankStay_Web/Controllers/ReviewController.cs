using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class ReviewController : Controller
    {
        readonly ReviewModel _reviewModel = new();

        //[FilterSessionValidation]
        [HttpGet]
        public async Task<IActionResult> Reviews()
        {
            return View(await _reviewModel.GetListReviews());
        }

        [HttpGet]
        public IActionResult RegisterReview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterReview(ReviewObj reviewObj)
        {
            return _reviewModel.RegisterReview(reviewObj) != null 
                ? RedirectToAction("Index", "Home") : View();
        }
    }
}