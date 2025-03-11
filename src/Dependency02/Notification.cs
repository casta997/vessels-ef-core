using Dependency02.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency02
{
    public class Notification
    {
        readonly IEmailService emailService;
        readonly ISmsService smsService;
        readonly IPushService pushService;
    }
}
