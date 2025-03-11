using Dependency01.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency01.Services
{
    public class PushService : INotificationService
    {
        public void Send(string msg)
        {
            Console.WriteLine(msg + " I'm a push");
        }
    }
}
