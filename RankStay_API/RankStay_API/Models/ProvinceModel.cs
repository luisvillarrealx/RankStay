using Dapper;
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

        public int RegisterProvince(ProvinceObj provinceObj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Execute("SP_RegisterProvince",
                    new
                    {
                        provinceObj.ProvinceName,
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public int PutProvince(ProvinceObj provinceObj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Execute("SP_UpdateProvince", new
                {
                    provinceObj.ProvinceId,
                    provinceObj.ProvinceName,
                    provinceObj.ProvinceDescription
                }, commandType: CommandType.StoredProcedure);
            }

        }

        public ProvinceObj GetProvince(int provinceId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                var sqlQuery = connection.Query<ProvinceObj>("SELECT * FROM PROVINCES WHERE ProvinceId = @ProvinceId ", new { ProvinceId = provinceId }).ToList();
                return sqlQuery.FirstOrDefault();
            }
        }
    }
}