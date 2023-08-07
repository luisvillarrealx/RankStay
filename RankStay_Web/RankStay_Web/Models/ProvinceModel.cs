using Newtonsoft.Json;
using RankStay_Web.Entities;
using System.Data;
using System.Data.SqlClient;

namespace RankStay_Web.Models
{
    public class ProvinceModel
    {
        public string? lblmsj { get; set; }
        public List<ProvinceObj> listProvince = new();
        ProvinceObj provinceObj = new();

        public List<ProvinceObj> GetListProvinces()
        {
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {
                    string urlApi = "https://localhost:7216/api/Province/getProvinces";
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
                    listProvince = JsonConvert.DeserializeObject<List<ProvinceObj>>(resultstr);
                }
            }
            return listProvince;
        }
    }
}