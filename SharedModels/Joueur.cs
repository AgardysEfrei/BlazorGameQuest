using System.Text.Json.Serialization;

namespace SharedModels;

public class Joueur
{
    public int joueurid { get; set; }
    public int utilisateurId { get; set; }
    public Utilisateur utilisateur { get; set; } = null!;
    [JsonIgnore]
    public ScorePartie? score { get; set; } 
}