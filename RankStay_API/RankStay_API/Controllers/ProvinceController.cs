using Microsoft.AspNetCore.Mvc;
using RankStay_API.Entities;
using RankStay_API.Models;

namespace RankStay_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinceController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ProvinceModel _provinceModel;

        public ProvinceController(IConfiguration configuration, ProvinceModel provinceModel)
        {
            _configuration = configuration;
            _provinceModel = provinceModel;
        }

        [HttpGet]
        [Route("GetProvinces")]
        public ActionResult<List<ProvinceObj>> GetProvinces()
        {
            return _provinceModel.GetListProvince();
        }

        [HttpPost]
        [Route("RegisterProvince")]
        public ActionResult RegisterProvince(ProvinceObj provinceObj)
        {
            return _provinceModel.RegisterProvince(provinceObj) > 0 ? Ok() : BadRequest();
        }

        [HttpPut]
        [Route("UpdateProvince")]
        public ActionResult UpdateProvince(ProvinceObj provinceObj)
        {
            try
            {
                if (provinceObj == null)
                    return NoContent();

                var result = _provinceModel.PutProvince(provinceObj);
                if (result > 0)
                {
                    return Ok(provinceObj);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetProvince/{provinceId}")]
        public ProvinceObj Get(int provinceId)
        {
            return _provinceModel.GetProvince(provinceId);
        }
    }
}