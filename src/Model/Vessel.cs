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

        public Owner Owner { get; set; }

        public override string ToString()
        {
            return $"\n- {Id} \t| - {ImoNumber} \t| - {OwnerId}";
        }
    }
}
