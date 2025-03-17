using DI_webApiNotification_001.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DI_webApiNotification_001.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController(IEmail email) : ControllerBase
{
    [HttpGet(Name = "GetEmail")]
    public IActionResult NotifyByEmail()
    {
        return Ok(email.Send("new email generated"));
    }
    /*
    [HttpGet(Name = "GetPush")]
    public IActionResult NotifyByPush()
    {
        return Ok(push.Send("new push executed"));
    }

    [HttpGet(Name = "GetSms")]
    public IActionResult NotifyBySms()
    {
        return Ok(sms.Send("new sms generated from microsoft"));
    }
    */
}
