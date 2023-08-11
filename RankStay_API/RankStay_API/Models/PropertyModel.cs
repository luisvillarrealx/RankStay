using Dapper;
using RankStay_API.Entities;
using System.Data;
using System.Data.SqlClient;

namespace RankStay_API.Models
{
    public class PropertyModel
    {
        private readonly IConfiguration _configuration;

        public PropertyModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ProvinceObj> ComboBoxProvince()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Query<ProvinceObj>("SELECT * FROM PROVINCES").ToList();
            }
        }

        public int RegisterProperty(PropertyObj propertyObj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Execute("SP_RegisterProperty",
                    new
                    {
                        propertyObj.PropertyProvinceId,
                        propertyObj.PropertyName,
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<PropertyObj> GetListProperties() // DEPRECATED
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Query<PropertyObj>("SP_GetAllProperties", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public PropertyObj GetPropertyById(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Query<PropertyObj>("SELECT * FROM PROPERTIES WHERE PropertyId =" + id.ToString()).ToList()[0];
            }
        }

        public List<PropertyObj> GetPropertiesByProvince(int provinceId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                connection.Open();
                return connection.Query<PropertyObj>("SP_GetPropertiesByProvince", new { PropertyProvinceId = provinceId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}