using System.Text.Json.Serialization;

namespace SharedModels;

public class Monstre
{
    public int monstreid { get; set; }
    public string nom { get; set; }
    public string description { get; set; }
    public string lienImage { get; set; }
    public int pointDeVie { get; set; }
    public double chanceToucher { get; set; }
    public double pointGagner { get; set; }
    [JsonIgnore]
    public int salleid { get; set; }
    [JsonIgnore]
    public Salles salle { get; set; } = null!;
}