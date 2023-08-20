using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class UserController : Controller
    {
        readonly UserModel _userModel = new();

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            return View(await _userModel.GetListUsers());
        }

        [HttpGet("User/EditUser/{userId}")]
        public async Task<IActionResult> EditUser(int userId)
        {
            return View(await _userModel.GetUser(userId));
        }

        [HttpPost]
        public ActionResult EditUser(UserObj userObj)
        {
            userObj.UserEmail = "email";
            userObj.UserPassword = "$yS9kw";
            return _userModel.PutUser(userObj) != null
                ? RedirectToAction("Users", "User") : View();
        }


    }
}