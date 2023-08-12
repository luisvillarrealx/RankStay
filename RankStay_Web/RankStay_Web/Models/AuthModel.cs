using RankStay_Web.Entities;

namespace RankStay_Web.Models
{
    public class AuthModel
    {
        public string? lblmsj { get; set; }

        public UserObj? Login(UserObj userObj)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Auth/Login";
                JsonContent content = JsonContent.Create(userObj);
                HttpResponseMessage response = access.PostAsync(urlApi, content).GetAwaiter().GetResult();

                return (response.IsSuccessStatusCode) ? response.Content.ReadFromJsonAsync<UserObj>().Result : null;
            }
        }

        public async Task<string> ResetPassword(UserObj userObj)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Auth/ResetPassword";
                JsonContent content = JsonContent.Create(userObj);
                try
                {
                    HttpResponseMessage response = await access.PutAsync(urlApi, content);

                    return response.IsSuccessStatusCode ? "OK" : string.Empty;
                }
                catch (Exception ex)
                {
                    return "An error occurred: " + ex.Message;
                }
            }
        }

        public string Signup(UserObj userObj)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Auth/Signup";
                JsonContent content = JsonContent.Create(userObj);
                HttpResponseMessage response = access.PostAsync(urlApi, content).GetAwaiter().GetResult();

                return (response.IsSuccessStatusCode) ? "OK" : string.Empty;
            }
        }
    }
}