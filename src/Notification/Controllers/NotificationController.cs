using Microsoft.AspNetCore.Mvc;
using Notification.Interfaces;

namespace Notification.Controllers
{
    [ApiController]
    [Route("notification")]
    public class NotificationController : Controller
    {
        private readonly IEmailService emailService;
        private readonly IPushService pushService;
        private readonly ISmsService smsService;

        public NotificationController(ISmsService smsService, IEmailService emailService, IPushService pushService)
        {
            this.pushService = pushService;
            this.smsService = smsService;
            this.emailService = emailService;
        }

        /*
        [HttpGet]
        public IActionResult GetAll(string input1, string input2, string input3)
        {
            var outputPush = pushService.send(input1);
            var outputSms = smsService.send(input2);
            var outputEmail = emailService.send(input3);
            return Ok(outputEmail + "\n" + outputPush + "\n" + outputSms);
        }
        */

        [HttpGet("mail")]
        public IActionResult GetEmail(string inputEmail)
        {
            var output = emailService.send(inputEmail);
            return Ok(output);
        }

        [HttpGet("sms")]
        public IActionResult GetSms(string inputSms)
        {
            var output = smsService.send(inputSms);
            return Ok(output);
        }

        [HttpGet("push")]
        public IActionResult GetPush(string inputPush)
        {
            var output = pushService.send(inputPush);
            return Ok(output);
        }
    }
}
