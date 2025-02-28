using Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application
{
    public class HumanMachine(ILogger<HumanMachine> logger) : IHumanMachineInterface
    {
        public string Read()
        {
            throw new NotImplementedException();
        }

        public void Write(string value)
        {
            logger.LogInformation(value);
        }
    }
}
