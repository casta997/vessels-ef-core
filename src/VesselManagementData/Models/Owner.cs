using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesselManagementData.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Vessel> Vessels { get; set;} = new List<Vessel>();
    }
}
