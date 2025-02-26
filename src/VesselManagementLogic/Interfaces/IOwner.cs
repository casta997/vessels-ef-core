using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesselManagementLogic.Interfaces
{
    public interface IOwner
    {
        public void Create();
        public void PrintTable();
        public void Update();
        public void Delete();
        public void AssignVessel();
    }
}
