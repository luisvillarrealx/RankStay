using Dapper;
using RankStay_API.Entities;
using System.Data;
using System.Data.SqlClient;

namespace RankStay_API.Models
{
    public class PropertyModel
    {
        public List<ProvinceObj> ComboBoxProvince(IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Query<ProvinceObj>("SELECT * FROM PROVINCES").ToList();
            }
        }

        public int RegisterProperty(PropertyObj propertyObj, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Execute("SP_RegisterProperty",
                    new
                    {
                        propertyObj.PropertyProvinceId,
                        propertyObj.PropertyName,
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<PropertyObj> GetListProperties(IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Query<PropertyObj>("SP_GetAllProperties", commandType: CommandType.StoredProcedure).ToList(); // despues de commandtype se pasa parametro de id
            }
        }

        public PropertyObj GetPropertyById(IConfiguration stringConnection, int id)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Query<PropertyObj>("SELECT * FROM PROPERTIES WHERE PropertyId =" + id.ToString()).ToList()[0];
            }
        }
    }
}