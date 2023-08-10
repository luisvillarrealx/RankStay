using Newtonsoft.Json;
using RankStay_Web.Entities;

namespace RankStay_Web.Models
{
    public class ReviewModel
    {
        public string? lblmsj { get; set; }
        public List<ReviewObj> listReview = new();

        public List<ReviewObj> GetListReviews()
        {
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {
                    string urlApi = "https://localhost:7216/api/Review/getReviews";
                    return await client.GetAsync(urlApi);
                }
                );
                HttpResponseMessage message = task.Result;
                if (message.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var task2 = Task<string>.Run(async () =>
                    {
                        return await message.Content.ReadAsStringAsync();
                    });
                    string resultstr = task2.Result;
                    listReview = JsonConvert.DeserializeObject<List<ReviewObj>>(resultstr);
                }
            }
            return listReview;
        }

        // get reviews based on property id == filtered reviews for selected property
        public async Task<List<ReviewObj>> GetReviewsByProperty(int propertyId)
        {
            using (var client = new HttpClient())
            {
                string urlApi = $"https://localhost:7216/api/Review/getReviewsByProperty/{propertyId}";

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
                        throw new Exception();
                        // Handle non-success status code if needed.
                        // For example: Log the error, throw an exception, etc.
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    // Handle exceptions that occurred during the request.
                    // For example: Log the error, throw a custom exception, etc.
                }

                return new List<ReviewObj>(); // Return an empty list on failure.
            }
        }


        public string RegisterReview(ReviewObj reviewObj)
        {
            using (HttpClient access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/" + "api/Review/RegisterReview";
                JsonContent content = JsonContent.Create(reviewObj);
                HttpResponseMessage response = access.PostAsync(urlApi, content).GetAwaiter().GetResult();

                return (response.IsSuccessStatusCode) ? "OK" : string.Empty;
            }
        }
    }
}