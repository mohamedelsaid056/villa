using System.Net;

namespace villa.Models
{
    public class ApiResponse
    {

        public HttpStatusCode statusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Message { get; set; }
        public object Result { get; set; }
    }
}
