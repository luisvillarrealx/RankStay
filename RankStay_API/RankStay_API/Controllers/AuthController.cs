using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RankStay_API.Entities;
using RankStay_API.Models;

namespace RankStay_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly AuthModel _authModel;

        public AuthController(IConfiguration configuration, AuthModel authModel)
        {
            _configuration = configuration;
            _authModel = authModel;
        }

        [HttpPut]
        [Route("ResetPassword")]
        public ActionResult ResetPassword(UserObj userObj)
        {
            return _authModel.ResetPassword(userObj) > 0 ? Ok(userObj) : BadRequest();
        }

        [HttpPost]
        [Route("ResetPasswordSmtp")]
        public void ResetPasswordSmtp(UserObj userObj)
        {
            _authModel.ResetPasswordSmtp(userObj);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<UserObj> login(UserObj userObj)
        {
            try
            {
                var data = _authModel.login(userObj);
                return (data != null) ? Ok(data) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al iniciar sesión. " + ex);
            }
        }

        [HttpPost]
        [Route("signup")]
        public ActionResult signup(UserObj userObj)
        {
            return _authModel.signup(userObj) > 0 ? Ok() : BadRequest();
        }
    }
}