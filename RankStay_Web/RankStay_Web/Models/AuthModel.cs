using RankStay_Web.Entities;

namespace RankStay_Web.Models
{
    public class AuthModel
    {
        public string? lblmsj { get; set; }
        readonly UserObj userObj = new();

        public UserObj? login(UserObj userObj)
        {
            using (HttpClient access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Auth/login";
                JsonContent content = JsonContent.Create(userObj);
                HttpResponseMessage response = access.PostAsync(urlApi, content).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<UserObj>().Result;
                else
                    return null;
            }
        }

        public string ResetPassword(UserObj userObj)
        {
            using (HttpClient access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/auth/ResetPassword";
                JsonContent content = JsonContent.Create(userObj);
                HttpResponseMessage response = access.PutAsync(urlApi, content).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode) {

                    return "OK";
                }
                return string.Empty;
            }
        
        }
        public string signup(UserObj userObj)
        {
            using (HttpClient access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Auth/signup";

                JsonContent content = JsonContent.Create(userObj);

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