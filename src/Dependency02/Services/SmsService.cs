using Dependency02.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency02.Services
{
    public class SmsService : ISmsService
    {
        public void Send(string msg)
        {
            Console.WriteLine(msg + " I'm a sms");
        }
    }
}
