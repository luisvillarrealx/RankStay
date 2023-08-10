using RankStay_Web.Entities;

namespace RankStay_Web.Models
{
    public class AuthModel
    {
        public string? lblmsj { get; set; }

        public UserObj? login(UserObj userObj)
        {
            using (HttpClient access = new())
            {
                string urlApi = "https://localhost:7216/api/Auth/login";
                JsonContent content = JsonContent.Create(userObj);
                HttpResponseMessage response = access.PostAsync(urlApi, content).GetAwaiter().GetResult();

                return (response.IsSuccessStatusCode) ? response.Content.ReadFromJsonAsync<UserObj>().Result : null;
            }
        }

        public string ResetPassword(UserObj userObj)
        {
            using (HttpClient access = new())
            {
                string urlApi = "https://localhost:7216/api/auth/ResetPassword";
                JsonContent content = JsonContent.Create(userObj);
                HttpResponseMessage response = access.PutAsync(urlApi, content).GetAwaiter().GetResult();

                return (response.IsSuccessStatusCode) ? "OK" : string.Empty;
            }
        
        }
        public string signup(UserObj userObj)
        {
            using (HttpClient access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Auth/signup";
                JsonContent content = JsonContent.Create(userObj);
                HttpResponseMessage response = access.PostAsync(urlApi, content).GetAwaiter().GetResult();

                return (response.IsSuccessStatusCode) ? "OK" : string.Empty;
            }
        }
    }
}