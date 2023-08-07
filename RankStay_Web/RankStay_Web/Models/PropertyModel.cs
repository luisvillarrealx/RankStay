using Newtonsoft.Json;
using RankStay_Web.Entities;

namespace RankStay_Web.Models
{
    public class PropertyModel
    {
        public string lblmsj { get; set; }
        PropertyObj propertyObj = new();

        public List<PropertyObj> listProperty = new();
        string urlGet = "https://localhost:7216/api/Property/GetPropertyById";
        public string RegisterProperty(PropertyObj propertyObj) {

            using (HttpClient access = new HttpClient()) {

                //string urlApi = "http://localhost/SERVICE/" + "api/PropertyApi/CreateProperty";
                string urlApi = "https://localhost:7216/" + "api/Property/RegisterProperty";

                JsonContent content = JsonContent.Create(propertyObj);

                HttpResponseMessage response = access.PostAsync(urlApi, content).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    return "OK";
                }
                return string.Empty;
            }
        }

        public List<PropertyObj> getListProperties()
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
    }
}