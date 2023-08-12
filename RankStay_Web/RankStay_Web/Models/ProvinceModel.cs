using Newtonsoft.Json;
using RankStay_Web.Entities;
using System.Collections.Generic;

namespace RankStay_Web.Models
{
    public class ProvinceModel
    {
        public string? lblmsj { get; set; }
        public List<ProvinceObj> listProvince = new();

        public async Task<List<ProvinceObj>> GetListProvinces()
        {
            using (var access = new HttpClient())
            {
                HttpResponseMessage response = await access.GetAsync("https://localhost:7216/api/Province/getProvinces");
                if (response.IsSuccessStatusCode)
                {
                    string resultstr = await response.Content.ReadAsStringAsync();
                    List<ProvinceObj>? list = JsonConvert.DeserializeObject<List<ProvinceObj>>(resultstr);
                    return list;
                }

                return new List<ProvinceObj>();
            }
        }
    }
}