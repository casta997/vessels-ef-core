using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Vessel
    {
        public int Id { get; set; }
        public string ImoNumber { get; set; }

        public int? OwnerId { get; set; }

        public override string ToString()
        {
            //var typeValueOwner = OwnerId.GetType().ToString();
            return $"Vessel information\n -Id: {Id} \t -IMO Number: {ImoNumber} \t -Type Value Owner: ";
        }
    }
}
