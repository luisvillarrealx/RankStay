using Newtonsoft.Json;
using RankStay_Web.Entities;

namespace RankStay_Web.Models
{
    public class ReviewModel
    {
        public string? lblmsj { get; set; }

        public async Task<List<ReviewObj>> GetListReviews()
        {
            using (var access = new HttpClient())
            {
                HttpResponseMessage message = await access.GetAsync("https://localhost:7216/api/Review/GetAllReviews");
                string resultStr = await message.Content.ReadAsStringAsync();
                List<ReviewObj>? list = JsonConvert.DeserializeObject<List<ReviewObj>>(resultStr);
                return list ?? new List<ReviewObj>();
            }
        }

        public async Task<List<ReviewObj>> GetReviewsByProperty(int propertyId)
        {
            using (var access = new HttpClient())
            {
                HttpResponseMessage response = await access.GetAsync($"https://localhost:7216/api/Review/GetReviewsByProperty/{propertyId}");
                string resultStr = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ReviewObj>>(resultStr) ?? new List<ReviewObj>();
            }
        }

        public async Task<string> RegisterReview(ReviewObj reviewObj)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Review/RegisterReview";
                JsonContent content = JsonContent.Create(reviewObj);
                HttpResponseMessage response = await access.PostAsync(urlApi, content);
                return response.IsSuccessStatusCode ? "OK" : string.Empty;
            }
        }

        public async Task<string> DeleteReview(int reviewId)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Review/DeleteReview";
                JsonContent content = JsonContent.Create(reviewId);
                HttpResponseMessage response = await access.PostAsync(urlApi, content);
                return response.IsSuccessStatusCode ? "OK" : string.Empty;
            }
        }
    }
}