using Newtonsoft.Json;
using RankStay_Web.Entities;
using System.Collections.Generic;

namespace RankStay_Web.Models
{
    public class UserModel
    {
        public string? lblmsj { get; set; }

        public async Task<List<UserObj>> GetListUsers()
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/User/GetAllUsers";
                HttpResponseMessage response = await access.GetAsync(urlApi);
                string resultstr = await response.Content.ReadAsStringAsync();
                List<UserObj>? list = JsonConvert.DeserializeObject<List<UserObj>>(resultstr);
                return list ?? new List<UserObj>();
            }
        }
    }
}