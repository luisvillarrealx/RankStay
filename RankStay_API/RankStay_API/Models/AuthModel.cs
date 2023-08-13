using Dapper;
using RankStay_API.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace RankStay_API.Models
{
    public class AuthModel
    {
        private readonly IConfiguration _configuration;

        public AuthModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool EmailExists(string UserEmail)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                var sqlQuery = connection.Query<UserObj>("SELECT * FROM USERS WHERE UserEmail = @UserEmail", new { UserEmail }).ToList();
                return sqlQuery.Any();
            }
        }

        public int ResetPassword(UserObj user)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Execute("SP_ResetPassword",
                    new
                    {
                        user.UserId,
                        user.UserPassword
                    }, commandType: CommandType.StoredProcedure);
            }
        }
        public void ResetPasswordSmtp(UserObj user)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                var respuesta = connection.QueryFirstOrDefault("SELECT * FROM USERS WHERE UserEmail  = @UserEmail", new { UserEmail = user.UserEmail });

                if (respuesta != null)
                {
                    string Subject = "Recuperar Contraseña";
                    string Body = "<html><body><h1>Sus credenciales</h1><p>Prueba 1 <b>recovery</b> message.</p></body></html>";
                    SendEmail(user.UserEmail, Subject, Body);
                }
            }
        }

        public void SendEmail(string Destination, string Subject, string Body)
        {
            string emailSMTP = "rankstay@outlook.com";
            string passwordSMTP = "Rank.Stay83!@%";

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(Destination, "User"));
            msg.From = new MailAddress(emailSMTP, "Admin");
            msg.Subject = Subject;
            msg.Body = Body;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(emailSMTP, passwordSMTP);
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Send(msg);
        }

        public UserObj? Login(UserObj userObj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Query<UserObj>("SP_LogIn",
                    new
                    {
                        userObj.UserEmail,
                        userObj.UserPassword
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public int Signup(UserObj userObj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Execute("SP_SignUp",
                    new
                    {
                        userObj.UserEmail,
                        userObj.UserPassword,
                    }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
