namespace DataProcessingAPI.Models
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }

        public static ServiceResult<T> CreateSuccess(T? data) 
        {
            return new ServiceResult<T> { Success = true, Data = data };
        }

        public static ServiceResult<T> CreateFailure(string errorMessage)
        {
            return new ServiceResult<T> { Success = false, ErrorMessage = errorMessage };
        }
    }
}
