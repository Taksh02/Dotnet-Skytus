using Microsoft.AspNetCore.Mvc;
using Assessment4.Services;

namespace Assessment4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IMessageService messageService,
            ILogger<HomeController> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Home Index action executed");
            ViewBag.Message = _messageService.GetMessage();
            return View();
        }
    }
}
