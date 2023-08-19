using Newtonsoft.Json;
using RankStay_Web.Entities;

namespace RankStay_Web.Models
{
    public class UserModel
    {
        public string? lblmsj { get; set; }

        public async Task<List<UserObj>> GetListUsers()
        {
            using (var access = new HttpClient())
            {
                HttpResponseMessage response = await access.GetAsync("https://localhost:7216/api/User/GetAllUsers");
                string resultstr = await response.Content.ReadAsStringAsync();
                List<UserObj>? list = JsonConvert.DeserializeObject<List<UserObj>>(resultstr);
                return list ?? new List<UserObj>();
            }
        }

        public async Task<string> PutUser(UserObj user)
        {
            using (var access = new HttpClient() ) 
            {
                string urlApi = "https://localhost:7216/api/User/PutUser";
                JsonContent content = JsonContent.Create(user);
                HttpResponseMessage response = await access.PutAsync(urlApi, content);
                return response.IsSuccessStatusCode ? "Ok" : string.Empty; 
            }
        }
    }
}