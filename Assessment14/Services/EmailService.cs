using Microsoft.Extensions.Logging;

namespace Assessment14.Services
{
    public class EmailService : IEmailService   // 👈 IMPORTANT
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                await Task.Delay(1000); // simulate sending

                _logger.LogInformation($"Email sent to {to}");
                _logger.LogInformation($"Subject: {subject}");
                _logger.LogInformation($"Body: {body}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
            }
        }
    }
}
