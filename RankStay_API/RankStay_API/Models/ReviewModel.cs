using Dapper;
using RankStay_API.Entities;
using System.Data;
using System.Data.SqlClient;

namespace RankStay_API.Models
{
    public class ReviewModel
    {
        private readonly IConfiguration _configuration;

        public ReviewModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int RegisterReview(ReviewObj reviewObj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Execute("SP_RegisterReview",
                    new
                    {
                        reviewObj.ReviewPropertyId,
                        reviewObj.ReviewComment,
                        reviewObj.ReviewStar,
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<ReviewObj> getListReviews()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Query<ReviewObj>("SP_GetReviews", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ReviewObj> GetReviewsByProperty(int propertyId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                //return connection.Query<ReviewObj>("SP_GetReviewsByProperty", propertyId, commandType: CommandType.StoredProcedure).ToList();
                connection.Open();
                return connection.Query<ReviewObj>("SP_GetReviewsByProperty", new { ReviewPropertyId = propertyId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}