using System.Text.Json.Serialization;

namespace SharedModels;

public class Donjons
{
    public int donjonsid { get; set; }
    public List<Salles> sallesList { get; set; } = new List<Salles>();

    [JsonIgnore]
    public ScorePartie? scorePartie { get; set; } = null!;
}