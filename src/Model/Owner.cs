using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Owner
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Vessel> Vessels { get; } = new List<Vessel>();

        public override string ToString()
        {
            return $"Owner information: \n\t-Id: {Id} \t-First name: {FirstName} \t-Last name: {LastName}";
        }
    }
}
