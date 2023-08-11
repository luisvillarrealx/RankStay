using Newtonsoft.Json;
using RankStay_Web.Entities;

namespace RankStay_Web.Models
{
    public class PropertyModel
    {
        public string lblmsj { get; set; }
        PropertyObj propertyObj = new();
        public List<PropertyObj> listProperty = new();
        readonly string urlGet = "https://localhost:7216/api/Property/GetPropertyById";

        public string RegisterProperty(PropertyObj propertyObj)
        {
            using (HttpClient access = new()) {

                string urlApi = "https://localhost:7216/api/Property/RegisterProperty";
                JsonContent content = JsonContent.Create(propertyObj);
                HttpResponseMessage response = access.PostAsync(urlApi, content).GetAwaiter().GetResult();

                return (response.IsSuccessStatusCode) ? "OK" : string.Empty;
            }
        }

        public List<PropertyObj> GetListProperties()
        {
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {
                    string urlApi = "https://localhost:7216/api/Property/GetProperties";
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
                    listProperty = JsonConvert.DeserializeObject<List<PropertyObj>>(resultstr);
                }
            }
            return listProperty;
        }

        public PropertyObj GetProperty(int id)
        {
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {
                    return await client.GetAsync(urlGet + "/" + id.ToString());
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
                    propertyObj = JsonConvert.DeserializeObject<PropertyObj>(resultstr);
                }
            }
            return propertyObj;
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