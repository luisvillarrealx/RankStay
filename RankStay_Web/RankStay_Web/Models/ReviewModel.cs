using Newtonsoft.Json;
using RankStay_Web.Entities;
using System.Data;
using System.Data.SqlClient;

namespace RankStay_Web.Models
{
    public class ReviewModel
    {
        public string? lblmsj { get; set; }
        public List<ReviewObj> listReview = new();
        ProvinceObj provinceObj = new();

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

        public string RegisterReview(ReviewObj reviewObj)
        {

            using (HttpClient access = new HttpClient())
            {

                //string urlApi = "http://localhost/SERVICE/" + "api/PropertyApi/CreateProperty";
                string urlApi = "https://localhost:7216/" + "api/Review/RegisterReview";

                JsonContent content = JsonContent.Create(reviewObj);

                HttpResponseMessage response = access.PostAsync(urlApi, content).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    return "OK";
                }
                return string.Empty;
            }
        }
    }
}