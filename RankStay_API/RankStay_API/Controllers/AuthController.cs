using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RankStay_API.Entities;
using RankStay_API.Models;

namespace RankStay_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        AuthModel authModel = new();

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPut]
        [Route("ResetPassword")]
        public ActionResult ResetPassword(UserObj userObj)
        {
            if (authModel.ResetPassword(userObj, _configuration) > 0)
            {
                return Ok(userObj);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("ResetPasswordSmtp")]
        public void ResetPasswordSmtp(UserObj userObj)
        {
            authModel.ResetPasswordSmtp(userObj, _configuration);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<UserObj> login(UserObj userObj)
        {
            try
            {
                var data = authModel.login(userObj, _configuration);
                if (data != null) return Ok(data);
                else return BadRequest();
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
            if (authModel.signup(userObj, _configuration) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}