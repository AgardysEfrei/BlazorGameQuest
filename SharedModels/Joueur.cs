using System.Text.Json.Serialization;

namespace SharedModels;

public class Joueur
{
    public int joueurid { get; set; }
    public required int utilisateurId { get; set; }
    public Utilisateur utilisateur { get; set; } = null!;
    [JsonIgnore]
    //Calculer le score d'un joueur reviendra à calculer le score contenu dans les parties
    public List<ScorePartie> score { get; set; } = new List<ScorePartie>(); 
}