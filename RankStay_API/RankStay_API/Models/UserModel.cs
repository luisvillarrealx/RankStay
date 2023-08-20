using Dapper;
using Microsoft.Extensions.Configuration;
using RankStay_API.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace RankStay_API.Models
{
    public class UserModel
    {
        private readonly IConfiguration _configuration;

        public UserModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<UserObj> GetListUsers()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Query<UserObj>("SP_GetAllUsers", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int PutUser(UserObj userObj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Execute("SP_UpdateUser", new
                {
                    userObj.UserId,
                    userObj.UserRole
                },commandType: CommandType.StoredProcedure);
            }

        }

        public UserObj GetUser(int userId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                var sqlQuery = connection.Query<UserObj>("SELECT * FROM USERS WHERE UserId = @UserId", new { UserId = userId }).ToList();
                return sqlQuery.FirstOrDefault();
            }
        }
    }
}