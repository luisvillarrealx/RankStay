using Newtonsoft.Json;
using RankStay_Web.Entities;

namespace RankStay_Web.Models
{
    public class PropertyModel
    {
        public string? lblmsj { get; set; }
        public List<PropertyObj> listProperty = new();

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
                string urlApi = $"https://localhost:7216/api/Property/GetPropertiesByProvince/{provinceId}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlApi);

                    if (response.IsSuccessStatusCode)
                    {
                        string resultStr = await response.Content.ReadAsStringAsync();
                        List<PropertyObj> reviews = JsonConvert.DeserializeObject<List<PropertyObj>>(resultStr);
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
                    // Log or inspect the exception details
                    Console.WriteLine("Exception: " + ex.Message);
                    // Optional: Log the stack trace for more detailed information
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    throw; // Re-throw the exception to propagate it further if needed
                }

                return new List<PropertyObj>(); // Return an empty list on failure.
            }
        }
    }
}