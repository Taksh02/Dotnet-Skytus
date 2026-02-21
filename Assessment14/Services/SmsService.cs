namespace Assessment14.Services
{
    public class SmsService : ISmsService
    {
        private readonly ILogger<SmsService> _logger;

        public SmsService(ILogger<SmsService> logger)
        {
            _logger = logger;
        }

        public Task SendSmsAsync(string number, string message)
        {
            _logger.LogInformation("SMS sent to {Number}: {Message}", number, message);
            return Task.CompletedTask;
        }
    }
}
