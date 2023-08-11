using Microsoft.AspNetCore.Mvc;
using RankStay_API.Entities;
using RankStay_API.Models;

namespace RankStay_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserModel _userModel;

        public UserController(IConfiguration configuration, UserModel userModel)
        {
            _configuration = configuration;
            _userModel = userModel;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<List<UserObj>> GetAllUsers()
        {
            return _userModel.GetListUsers();
        }
    }
}