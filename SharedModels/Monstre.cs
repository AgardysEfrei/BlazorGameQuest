using System.Text.Json.Serialization;

namespace SharedModels;

public class Monstre
{
    public int monstreid { get; set; }
    public string nom { get; set; }
    public string description { get; set; }
    [JsonIgnore]
    public int salleid { get; set; }
    [JsonIgnore]
    public Salles salle { get; set; } = null!;
}