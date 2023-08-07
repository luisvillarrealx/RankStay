using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RankStay_API.Entities;
using RankStay_API.Models;

namespace RankStay_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IConfiguration _configuration;
        ReviewModel reviewModel = new();
        ProvinceModel provinceModel = new();

        public ReviewController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getReviews")]
        public ActionResult<List<ReviewObj>> Get()
        {
            return reviewModel.getListReviews(_configuration);
        }

        [HttpPost]
        [Route("RegisterReview")]
        public ActionResult RegisterReview(ReviewObj reviewObj)
        {
            if (reviewModel.RegisterReview(reviewObj, _configuration) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        //[HttpGet("GetPropertyById/{id}")]
        //public ActionResult<PropertyObj> Get(int id)
        //{
        //    var property = propertyModel.GetPropertyById(_configuration, id);
        //    if (property == null)
        //    {
        //        return NotFound();
        //    }
        //    return property;
        //}
    }
}