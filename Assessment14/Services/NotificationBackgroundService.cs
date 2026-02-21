using Microsoft.Extensions.Hosting;

namespace Assessment14.Services
{
    public class NotificationBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<NotificationBackgroundService> _logger;

        public NotificationBackgroundService(
            IServiceScopeFactory scopeFactory,
            ILogger<NotificationBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background Notification Service Started");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                        var smsService = scope.ServiceProvider.GetRequiredService<ISmsService>();

                        _logger.LogInformation("Executing scheduled task at {Time}", DateTime.Now);

                        await emailService.SendEmailAsync(
                            "recipient@gmail.com",
                            "Scheduled Notification",
                            $"Notification triggered at {DateTime.Now}");

                        await smsService.SendSmsAsync(
                            "+911234567890",
                            $"SMS Notification at {DateTime.Now}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred in background service");
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }

            _logger.LogInformation("Background Notification Service Stopped");
        }
    }
}
