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

        [HttpGet]
        [Route("getReviews")]
        public ActionResult<List<ReviewObj>> Get()
        {
            return _reviewModel.getListReviews();
        }

        [HttpPost]
        [Route("RegisterReview")]
        public ActionResult RegisterReview(ReviewObj reviewObj)
        {
            if (_reviewModel.RegisterReview(reviewObj) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetReviewsByProperty/{propertyId}")]
        public ActionResult<List<ReviewObj>> GetReviewsByProperty(int propertyId)
        {
            try
            {
                var reviews = _reviewModel.GetReviewsByProperty(propertyId);
                if (reviews.Count == 0)
                {
                    // Return an empty list with a 200 status code if no reviews were found
                    return Ok(reviews);
                }
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, and return an appropriate error response
                Console.WriteLine("Error in GetReviewsByProperty: " + ex.Message);
                return StatusCode(500, "An error occurred while fetching reviews.");
            }
        }
    }
}