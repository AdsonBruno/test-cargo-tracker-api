namespace test_cargo_tracker_api.src.Models
{
    public class ServiceResponse<T>
    {
        public T? Date { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
    }
}
