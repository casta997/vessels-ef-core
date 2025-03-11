using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency01.Interfaces
{
    public interface INotificationService
    {
        void Send(string msg);
    }
}
