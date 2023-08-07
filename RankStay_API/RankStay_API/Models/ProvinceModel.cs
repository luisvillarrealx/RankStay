using Dapper;
using RankStay_API.Entities;
using System.Data;
using System.Data.SqlClient;

namespace RankStay_API.Models
{
    public class ProvinceModel
    {
        public List<ProvinceObj> getListProvince(IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Query<ProvinceObj>("SP_GetProvinces", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ProvinceObj> ComboBoxProvince(IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Query<ProvinceObj>("SP_GetProvinces", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}