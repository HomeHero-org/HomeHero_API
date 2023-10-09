using System.Net;

namespace HomeHero_API.Models
{
    public class ApiAnswer
    {
        public ApiAnswer()
        {
            Messages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool isSuccess { get; set; } = true;
        public List<string> Messages { get; set; }
        public object Result { get; set; }

    }
}
