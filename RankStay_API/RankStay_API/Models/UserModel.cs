using Dapper;
using RankStay_API.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace RankStay_API.Models
{
    public class UserModel
    {
        public List<UserObj> GetListUsers(IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Query<UserObj>("SP_GetAllUsers", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}