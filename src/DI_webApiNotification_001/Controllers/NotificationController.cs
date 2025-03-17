using DI_webApiNotification_001.Data.Entities;
using DI_webApiNotification_001.DTOs;
using DI_webApiNotification_001.EnumClasses;
using DI_webApiNotification_001.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DI_webApiNotification_001.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController(INotification notification) : ControllerBase
{
    /*
    [HttpPost("email")]
    public IActionResult NotifyByEmail([FromBody] MessageRequest requestBody)
    {
        var message = requestBody.Message;
        return Ok(email.Send(message));
    }
    
    [HttpGet("push")]
    public IActionResult NotifyByPush()
    {
        return Ok(push.Send("new push executed"));
    }

    [HttpGet("sms")]
    public IActionResult NotifyBySms()
    {
        return Ok(sms.Send("new sms generated from microsoft"));
    }
    */
    [HttpGet("sms")]
    public IActionResult NotifyBySms()
    {
        
        return Ok(notification.Send("ddd", ETypeNotification.Sms));
    }


    [HttpGet("push")]
    public IActionResult NotifyByPush()
    {
        
        return Ok(notification.Send("new push generated from microsoft", ETypeNotification.Push));
    }

    [HttpGet("email")]
    public IActionResult NotifyByEmail()
    {
        
        return Ok(notification.Send("new email generated from microsoft", ETypeNotification.Email));
    }

}
