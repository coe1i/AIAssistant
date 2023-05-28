using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace openai.Models
{
    // serves as our input model
    public class input
    {
        public string? prompt { get; set; }
        public short? n { get; set; }
        public string? size { get; set; }
    }

    // model for the image url
    public class Link
    {
        public string? url { get; set; }
    }

    // model for the DALL E api response
    public class ResponseModel
    {
        public long created { get; set; }
        public List<Link>? data { get; set; }
    }

}
