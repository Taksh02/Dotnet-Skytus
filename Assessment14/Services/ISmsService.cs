namespace Assessment14.Services
{
    public interface ISmsService
    {
        Task SendSmsAsync(string number, string message);
    }
}
