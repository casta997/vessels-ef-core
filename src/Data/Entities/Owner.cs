namespace Data.Entities;

public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Vessel> Vessels { get; set; }
}
