﻿using Newtonsoft.Json;
using RankStay_Web.Entities;

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
                string resultstr = await response.Content.ReadAsStringAsync();
                List<ProvinceObj>? list = JsonConvert.DeserializeObject<List<ProvinceObj>>(resultstr);
                return list ?? new List<ProvinceObj>();
            }
        }

        public async Task<string> RegisterProvince(ProvinceObj provinceObj)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Province/RegisterProvince";
                JsonContent content = JsonContent.Create(provinceObj);
                HttpResponseMessage response = await access.PostAsync(urlApi, content);
                return response.IsSuccessStatusCode ? "OK" : string.Empty;
            }
        }

        public async Task<string> PutProvince(ProvinceObj provinceObj)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Province/UpdateProvince";
                JsonContent content = JsonContent.Create(provinceObj);
                HttpResponseMessage response = await access.PutAsync(urlApi, content);
                return response.IsSuccessStatusCode ? "Ok" : string.Empty;
            }
        }

        public async Task<ProvinceObj> GetProvince(int id)
        {
            using (var access = new HttpClient())
            {
                HttpResponseMessage response = await access.GetAsync($"https://localhost:7216/api/Province/GetProvince/{id}");
                string resultstr = await response.Content.ReadAsStringAsync();
                ProvinceObj provinceObj = JsonConvert.DeserializeObject<ProvinceObj>(resultstr);
                return provinceObj;
            }
        }

    }
}