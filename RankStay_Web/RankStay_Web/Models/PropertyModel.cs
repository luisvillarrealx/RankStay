using Newtonsoft.Json;
using RankStay_Web.Entities;

namespace RankStay_Web.Models
{
    public class PropertyModel
    {
        public string? lblmsj { get; set; }

        public async Task<string> RegisterProperty(PropertyObj propertyObj)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Property/RegisterProperty";
                JsonContent content = JsonContent.Create(propertyObj);
                HttpResponseMessage response = await access.PostAsync(urlApi, content);
                return response.IsSuccessStatusCode ? "OK" : string.Empty;
            }
        }

        public async Task<List<PropertyObj>> GetListProperties()
        {
            using (var access = new HttpClient())
            {
                HttpResponseMessage response = await access.GetAsync("https://localhost:7216/api/Property/GetProperties");
                string resultstr = await response.Content.ReadAsStringAsync();
                List<PropertyObj>? list = JsonConvert.DeserializeObject<List<PropertyObj>>(resultstr);
                return list ?? new List<PropertyObj>();
            }
        }

        public async Task<List<PropertyObj>> GetProperty(int id)
        {
            using (var access = new HttpClient())
            {
                HttpResponseMessage response = await access.GetAsync($"https://localhost:7216/api/Property/GetPropertyById{id}");
                string resultstr = await response.Content.ReadAsStringAsync();
                List<PropertyObj>? list = JsonConvert.DeserializeObject<List<PropertyObj>>(resultstr);
                return list ?? new List<PropertyObj>();
            }
        }

        public async Task<List<PropertyObj>> GetPropertiesByProvince(int provinceId)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:7216/api/Property/GetPropertiesByProvince/{provinceId}");
                string resultStr = await response.Content.ReadAsStringAsync();
                List<PropertyObj>? reviews = JsonConvert.DeserializeObject<List<PropertyObj>>(resultStr);
                return reviews ?? new List<PropertyObj>();
            }
        }
    }
}