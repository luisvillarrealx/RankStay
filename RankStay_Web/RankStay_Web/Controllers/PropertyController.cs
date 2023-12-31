﻿using Microsoft.AspNetCore.Mvc;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class PropertyController : Controller
    {
        readonly PropertyModel _propertyModel = new();
        readonly ReviewModel _reviewModel = new();

        //[FilterSessionValidation]
        [HttpGet]
        public IActionResult RegisterProperty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterProperty(PropertyObj propertyObj)
        {
            return _propertyModel.RegisterProperty(propertyObj) != null
                ? RedirectToAction("Index", "Home") : View();
        }


        [HttpGet("Property/Property/{propertyId}")]
        public async Task<IActionResult> Property(int propertyId)
        {
            return View(await _reviewModel.GetReviewsByProperty(propertyId));
        }
    }
}