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
        public IActionResult login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult login(UserObj userObj)
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
                return RedirectToAction(nameof(login));
            }
        }


        [HttpGet]
        public IActionResult signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult signup(UserObj userObj)
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

        public IActionResult forgot()
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