using System.Net;

namespace TheMoviesAPI.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }

        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
