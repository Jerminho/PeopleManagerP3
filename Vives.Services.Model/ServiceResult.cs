namespace Vives.Services.Model
{
    public class ServiceResult
    {
        public IList<ServiceMessage> Messages { get; set; } = new List<ServiceMessage>();
        public bool IsSuccess => Messages.All(m => m.Type != MessageType.Error);
    }
}
