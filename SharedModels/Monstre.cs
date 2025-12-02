using System.Text.Json.Serialization;

namespace SharedModels;

public class Monstre
{
    public int monstreid { get; set; }
    public required string nom { get; set; }
    public required string description { get; set; }
    public required string lienImage { get; set; }
    public required int pointDeVie { get; set; }
    public required double chanceToucher { get; set; }
    public required double pointGagner { get; set; }
    [JsonIgnore]
    public Salles salle { get; set; } = null!;
}