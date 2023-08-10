using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class AuthController : Controller
    {
        readonly UserObj userObj = new();
        readonly UserModel usermodel = new();
        readonly AuthModel authModel = new();

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
                userObj.UserName = "luis";
                userObj.UserLastName1 = "Villarreal";
                userObj.UserLastName2 = "Retes";
                userObj.UserRole = 1;
                var result = authModel.login(userObj);
                if (result != null)
                {
                    HttpContext.Session.SetString("UserEmail", result.UserEmail);
                    HttpContext.Session.SetString("UserName", result.UserName);
                    HttpContext.Session.SetString("UserLastName1", result.UserLastName1);
                    HttpContext.Session.SetString("UserLastName2", result.UserLastName2);
                    HttpContext.Session.SetString("UserRole", result.UserRole.ToString());
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ViewBag.MsjError = "La información indicada es incorrecta.";
                    return View("login");
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
            userObj.UserName = "luis";
            userObj.UserLastName1 = "Villarreal";
            userObj.UserLastName2 = "Retes";
            userObj.UserRole = 1;

            if (authModel.signup(userObj) != string.Empty)
            {
                return RedirectToAction("login", "Auth");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Forgot()
        {
            //HttpContext.Session.Clear();
            return View();
        }

        public ActionResult ResetPassword(int id)
        {
            userObj.UserId = id;
            return View(userObj);
        }

        [HttpPost]
        public ActionResult ResetPassword(UserObj userObj)
        {
            authModel.ResetPassword(userObj);
            return RedirectToAction("login", "auth");
        }
    }
}