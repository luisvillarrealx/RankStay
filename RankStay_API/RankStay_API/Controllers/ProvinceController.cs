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
    }
}