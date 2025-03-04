namespace Data.Entities;

public class Owner
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public List<Vessel> Vessels { get; } = new List<Vessel>();

    public override string ToString()
    {
        return $"\n {Id} \t| - {FirstName} \t\t| - {LastName}";
    }
}
