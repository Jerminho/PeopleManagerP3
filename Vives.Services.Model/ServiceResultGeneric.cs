namespace Vives.Services.Model
{
    public class ServiceResult<T>: ServiceResult
    {
        public T? Data { get; set; }
    }
}
