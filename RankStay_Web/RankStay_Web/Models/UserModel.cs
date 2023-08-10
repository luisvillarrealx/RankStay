using Newtonsoft.Json;
using RankStay_Web.Entities;

namespace RankStay_Web.Models
{
    public class UserModel
    {
        public string? lblmsj { get; set; }
        List<UserObj> listUser = new();

        public List<UserObj> GetListUsers()
        {
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {
                    string urlApi = "https://localhost:7216/api/User/GetAllUsers";
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
                    listUser = JsonConvert.DeserializeObject<List<UserObj>>(resultstr);
                }
            }
            return listUser;
        }
    }
}