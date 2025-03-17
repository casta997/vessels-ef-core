using Microsoft.AspNetCore.Mvc;
using NotificationV2.Interfaces;

namespace NotificationV2.Controllers
{
    [ApiController]
    [Route("Message")]
    public class MessageController(INotificationService notificationService) : Controller
    {
        [HttpGet("sms")]
        public IActionResult GetSms()
        {
            var sms = notificationService.Send("Ciao ", "sms");
            return Ok(sms);
        }

        [HttpGet("email")]
        public IActionResult GetEmail()
        {
            var email = notificationService.Send("Ciao ", "email");
            return Ok(email);
        }

        [HttpGet("push")]
        public IActionResult GetPush()
        {
            var push = notificationService.Send("Ciao ", "push");
            return Ok(push);
        }
    }
}
