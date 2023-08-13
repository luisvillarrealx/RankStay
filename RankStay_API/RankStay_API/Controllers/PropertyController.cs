using Microsoft.AspNetCore.Mvc;
using RankStay_API.Entities;
using RankStay_API.Models;

namespace RankStay_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly PropertyModel _propertyModel;

        public PropertyController(IConfiguration configuration, PropertyModel propertyModel)
        {
            _configuration = configuration;
            _propertyModel = propertyModel;
        }

        [HttpPost]
        [Route("RegisterProperty")]
        public ActionResult RegisterProperty(PropertyObj propertyObj)
        {
            return _propertyModel.RegisterProperty(propertyObj) > 0 ? Ok() : BadRequest();
        }

        [HttpGet("GetProperties")]
        public ActionResult<List<PropertyObj>> Get()
        {
            return _propertyModel.GetListProperties();
        }

        [HttpGet("GetPropertyById/{id}")]
        public ActionResult<PropertyObj> Get(int id)
        {
            var property = _propertyModel.GetPropertyById(id);
            return property != null ? property : NotFound();
        }

        [HttpGet("GetPropertiesByProvince/{provinceId}")]
        public ActionResult<List<PropertyObj>> GetPropertiesByProvince(int provinceId)
        {
            try
            {
                var properties = _propertyModel.GetPropertiesByProvince(provinceId);
                return properties != null ? properties : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching properties." + ex.Message);
            }
        }
    }
}
