using System.Text.Json.Serialization;

namespace SharedModels;

public class Salles
{
    public int salleId { get; set; }
    [JsonIgnore]
    public List<Donjons> donjonsList { get; } = [];
    [JsonIgnore]
    public Monstre? monstre { get; set; }
}