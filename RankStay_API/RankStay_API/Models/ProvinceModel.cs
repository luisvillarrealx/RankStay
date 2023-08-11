﻿using Dapper;
using RankStay_API.Entities;
using System.Data;
using System.Data.SqlClient;

namespace RankStay_API.Models
{
    public class ProvinceModel
    {
        private readonly IConfiguration _configuration;

        public ProvinceModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ProvinceObj> GetListProvince()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Query<ProvinceObj>("SP_GetProvinces", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ProvinceObj> ComboBoxProvince()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Query<ProvinceObj>("SP_GetProvinces", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}