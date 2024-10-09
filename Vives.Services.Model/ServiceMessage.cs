namespace Vives.Services.Model
{
    public class ServiceMessage
    {
        public required string Code { get; set; }
        public required string Message { get; set; }
        public MessageType Type { get; set; }
    }
}
