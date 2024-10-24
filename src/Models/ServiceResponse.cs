using System.Net;

namespace test_cargo_tracker_api.src.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
        public int statusCode { get; set; }
    }
}
