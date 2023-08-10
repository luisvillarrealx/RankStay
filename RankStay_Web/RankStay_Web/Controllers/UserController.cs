using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class UserController : Controller
    {
        readonly UserModel userModel = new();

        [HttpGet]
        public IActionResult Users()
        {
            return View(userModel.GetListUsers());
        }
    }
}