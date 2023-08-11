using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RankStay_Web.Entities;
using RankStay_Web.Models;

namespace RankStay_Web.Controllers
{
    public class ReviewController : Controller
    {
        readonly ReviewModel _reviewModel = new();

        //[FilterSessionValidation]
        [HttpGet]
        public IActionResult RegisterReview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterReview(ReviewObj reviewObj)
        {
            //reviewObj.PorpertyReviewComment = "Comment";
            //reviewObj.PorpertyReviewStar = 0.0;
            //reviewObj.PropetyDescription = "Description";
            //reviewObj.PropertyUserId = 1;

            if (_reviewModel.RegisterReview(reviewObj) != string.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        //[HttpGet]
        //public IActionResult Reviews__()
        //{
        //    return View(reviewModel.GetListReviews());
        //}

        //[HttpGet]
        //public IActionResult Reviews1(int propertyId)
        //{
        //    return View(reviewModel.GetReviewsByProperty(propertyId));
        //}

        public async Task<List<ReviewObj>> GetReviewsByProperty(int propertyId)
        {
            using (var client = new HttpClient())
            {
                string urlApi = $"https://localhost:7216/api/Review/GetReviewsByProperty/{propertyId}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlApi);

                    if (response.IsSuccessStatusCode)
                    {
                        string resultStr = await response.Content.ReadAsStringAsync();
                        List<ReviewObj> reviews = JsonConvert.DeserializeObject<List<ReviewObj>>(resultStr);
                        return reviews;
                    }
                    else
                    {
                        string errorMsg = $"API request failed with status code: {response.StatusCode}";
                        throw new HttpRequestException(errorMsg);
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("HTTP Request Exception: " + ex.Message);
                    throw; // Re-throw the exception to propagate it further if needed
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw; // Re-throw the exception to propagate it further if needed
                }

                return new List<ReviewObj>(); // Return an empty list on failure.
            }
        }

    }
}