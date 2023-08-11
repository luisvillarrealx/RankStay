using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RankStay_API.Entities;
using RankStay_API.Models;
using System;
using System.Collections.Generic;

namespace RankStay_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ReviewModel _reviewModel;

        public ReviewController(IConfiguration configuration, ReviewModel reviewModel)
        {
            _configuration = configuration;
            _reviewModel = reviewModel;
        }

        //[HttpGet("GetReviews")]
        //public ActionResult<List<ReviewObj>> GetReviews()
        //{
        //    return _reviewModel.GetListReviews();
        //}

        [HttpPost]
        [Route("RegisterReview")]
        public ActionResult RegisterReview(ReviewObj reviewObj)
        {
            return (_reviewModel.RegisterReview(reviewObj) > 0) ? Ok() : BadRequest();
        }

        [HttpGet("GetReviewsByProperty/{propertyId}")]
        public ActionResult<List<ReviewObj>> GetReviewsByProperty(int propertyId)
        {
            try
            {
                var reviews = _reviewModel.GetReviewsByProperty(propertyId);
                return reviews.Count != 0 ? Ok(reviews) : BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching reviews." + ex.Message);
            }
        }
    }
}