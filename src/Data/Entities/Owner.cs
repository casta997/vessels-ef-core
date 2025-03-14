using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class Owner
{
    [Key]
    public int Id { get; set; }

    [MaxLength(250)]
    public string FirstName { get; set; }

    [MaxLength(250)]
    public string LastName { get; set; }

    public List<Vessel> Vessels { get; } = new List<Vessel>();

    public override string ToString()
    {
        return $"\n {Id} \t| {FirstName} \t\t| {LastName}";
    }
}
