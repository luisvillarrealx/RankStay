using Dapper;
using RankStay_API.Entities;
using System.Data;
using System.Data.SqlClient;

namespace RankStay_API.Models
{
    public class ReviewModel
    {
        public int RegisterReview(ReviewObj reviewObj, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
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

        public List<ReviewObj> getListReviews(IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Query<ReviewObj>("SP_GetReviews", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}