using System.Text.Json.Serialization;

namespace SharedModels;

public class Salles
{
    public int salleId { get; set; }
    public double scoreBonus { get; set; }
    [JsonIgnore]
    public List<Donjons> donjonsList { get; } = new List<Donjons>();
    public int monstreId { get; set; }
    public Monstre? monstre { get; set; }
}