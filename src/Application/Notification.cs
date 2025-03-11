using Dependency01.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency01
{
    public class Notification
    {
        readonly INotificationService notificationService;

        public Notification(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
    }
}
