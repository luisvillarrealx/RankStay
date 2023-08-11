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
    }
}