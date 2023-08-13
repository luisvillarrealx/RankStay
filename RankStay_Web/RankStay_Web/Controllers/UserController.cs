using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult EditUser()
        {
            return View();
        }
    }
}