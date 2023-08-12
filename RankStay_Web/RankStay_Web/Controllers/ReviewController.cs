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

        [HttpGet]
        public async Task<IActionResult> Reviews()
        {
            return View(await _reviewModel.GetListReviews());
        }

        [HttpPost]
        public ActionResult RegisterReview(ReviewObj reviewObj)
        {
            return _reviewModel.RegisterReview(reviewObj) != null ? RedirectToAction("Index", "Home") : View();
        }

        public async Task<List<ReviewObj>> GetReviewsByProperty(int propertyId) //NEVER USED
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://localhost:7216/api/Review/GetReviewsByProperty/{propertyId}");

                    if (response.IsSuccessStatusCode)
                    {
                        string resultStr = await response.Content.ReadAsStringAsync();
                        List<ReviewObj>? reviews = JsonConvert.DeserializeObject<List<ReviewObj>>(resultStr);
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
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw;
                }

                return new List<ReviewObj>(); // Return an empty list on failure.
            }
        }
    }
}