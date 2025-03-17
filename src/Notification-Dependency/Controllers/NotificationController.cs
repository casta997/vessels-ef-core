using Microsoft.AspNetCore.Mvc;
using Notification_Dependency.Interfaces;

namespace Notification_Dependency.Controllers
{
    [ApiController]
    [Route("notifiaction")]
    public class NotificationController : Controller
    {
        private readonly IEmailService emailService;
        private readonly IPushService pushService;
        private readonly ISmsService smsService;

        public NotificationController(IEmailService emailService, IPushService pushService, ISmsService smsService)
        {
            this.smsService = smsService;
            this.emailService = emailService;
            this.pushService = pushService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            smsService.send("ciao ");
            emailService.send("ciao ");
            pushService.send("ciao ");
            return Ok();
        }

        [HttpGet]
        public IActionResult GetSms()
        {
            smsService.send("ciao ");
            return Ok();
        }

        [HttpGet]
        public IActionResult GetEmail()
        {
            emailService.send("ciao ");
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPush()
        {
            pushService.send("ciao ");
            return Ok();
        }
    }
}
