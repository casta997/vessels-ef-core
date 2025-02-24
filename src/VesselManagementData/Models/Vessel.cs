using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesselManagementData.Models
{
    public class Vessel
    {
        public int Id { get; set; }
        public string ImoNumber { get; set; }
        public Owner Owner { get; set; }
        public int? OwnerId { get; set; }
    }
}
