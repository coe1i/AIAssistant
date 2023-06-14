using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using openai.Models;
using openai.Recursos.ChatGPT;

using RestSharp;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace openai.Controllers
{
    public class DallEController : Controller
    {
        public static string _EndPoint = "https://api.openai.com/";
        public static string _URI = "https://api.openai.com/v1/images/generations";
        public static string _APIKey = "b";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateImage([FromBody] input input)
        {
            var resp = new ResponseModel();
            using (var client = new HttpClient())
            {
                // quitamos el header si existe
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "b");
                var Message = await client.PostAsync("https://api.openai.com/v1/images/generations",
                    new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json"));

                if (Message.IsSuccessStatusCode)
                {

                    var content = await Message.Content.ReadAsStringAsync();
                    resp = JsonConvert.DeserializeObject<ResponseModel>(content);
                }
            }


            return Json(resp);
        }

    }
}

