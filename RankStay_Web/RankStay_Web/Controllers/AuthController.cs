using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class AuthController : Controller
    {
        readonly UserModel _userModel = new();
        readonly AuthModel _authModel = new();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserObj userObj)
        {
            try
            {
                userObj.UserName = "name";
                userObj.UserLastName1 = "lastname1";
                userObj.UserLastName2 = "lastname1";
                userObj.UserRole = 2;
                var result = _authModel.Login(userObj);
                if (result != null)
                {
                    HttpContext.Session.SetString("UserEmail", result.UserEmail ?? "");
                    HttpContext.Session.SetString("UserName", result.UserName ?? "");
                    HttpContext.Session.SetString("UserLastName1", result.UserLastName1 ?? "");
                    HttpContext.Session.SetString("UserLastName2", result.UserLastName2 ?? "");
                    HttpContext.Session.SetString("UserRole", result.UserRole.ToString() ?? "2");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.MsjError = "La información indicada es incorrecta.";
                    return View("Login");
                }
            }
            catch
            {
                return RedirectToAction(nameof(Login));
            }
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(UserObj userObj)
        {
            userObj.UserName = "name";
            userObj.UserLastName1 = "lastname1";
            userObj.UserLastName2 = "lastname2";
            userObj.UserRole = 2;
            return _authModel.Signup(userObj) != null
                ? RedirectToAction("Login", "Auth") : View();
        }

        public IActionResult Forgot()
        {
            //HttpContext.Session.Clear();
            return View();
        }

        //public ActionResult ResetPassword(int id)
        //{
        //    userObj.UserId = id;
        //    return View(userObj);
        //}

        [HttpPost]
        public async Task<ActionResult> Forgot(UserObj userObj)
        {
            await _authModel.ResetPassword(userObj);
            return RedirectToAction("Login", "Auth");
        }
    }
}