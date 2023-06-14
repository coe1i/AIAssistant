using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace openai.Models
{
    public class Subscriber
    { 
        public int? id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Agree { get; set; }
    }

             
}
