using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using openai.Models;
//using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.Data.SqlClient;

namespace openai.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IConfiguration _configuration;

        public SubscriptionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("subscribe")]
        public IActionResult Subscribe(Subscriber subscriber)
        {
         
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "INSERT INTO usuarios (Name, Surname, email, agree) VALUES (@Name, @Surname, @Email, @Agree);";
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.Add(new SqlParameter("Name", subscriber.Name));
                    command.Parameters.Add(new SqlParameter("Surname", subscriber.Surname));
                    command.Parameters.Add(new SqlParameter("Email", subscriber.Email));
                    command.Parameters.Add(new SqlParameter("Agree", subscriber.Agree));
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return RedirectToAction("Index");
        }
    }

}

