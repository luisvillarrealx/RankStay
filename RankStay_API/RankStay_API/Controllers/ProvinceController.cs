using Microsoft.AspNetCore.Mvc;
using RankStay_API.Entities;
using RankStay_API.Models;

namespace RankStay_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : Controller
    {
        public ProvinceModel provinceModel = new(); 
        private readonly IConfiguration _configuration;

        public ProvinceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getProvinces")]
        public ActionResult<List<ProvinceObj>> get()
        {
            return provinceModel.getListProvince(_configuration);
        }
    }
}