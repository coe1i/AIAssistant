using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace openai.Models
{
    public class input
    {
        public string? prompt { get; set; }
        public short? n { get; set; }
        public string? size { get; set; }
    }

   
    public class Link
    {
        public string? url { get; set; }
    }

   
    public class ResponseModel
    {
        public long created { get; set; }
        public List<Link>? data { get; set; }
    }

}
