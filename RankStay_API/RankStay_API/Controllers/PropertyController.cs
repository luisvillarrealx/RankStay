using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RankStay_API.Entities;
using RankStay_API.Models;

namespace RankStay_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : Controller
    {
        private readonly IConfiguration _configuration;
        PropertyModel propertyModel = new();
        ProvinceModel provinceModel = new();

        public PropertyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("RegisterProperty")]
        public ActionResult RegisterProperty(PropertyObj propertyObj)
        {
            if (propertyModel.RegisterProperty(propertyObj, _configuration) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetProperties")]
        public ActionResult<List<PropertyObj>> Get()
        {
            return propertyModel.GetListProperties(_configuration);
        }

        [HttpGet("GetPropertyById/{id}")]
        public ActionResult<PropertyObj> Get(int id)
        {
            var property = propertyModel.GetPropertyById(_configuration, id);
            if (property == null)
            {
                return NotFound();
            }
            return property;
        }
    }
}
