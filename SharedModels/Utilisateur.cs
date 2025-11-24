using System.Text.Json.Serialization;
namespace SharedModels;

public class Utilisateur
{
    public int utilisateurId { get; set; }
    [JsonIgnore]
    public Administrateur? administrateur { get; set; }
    [JsonIgnore]
    public Joueur? joueur { get; set; }
    public String nom { get; set; }
    public String prenom { get; set; }
    public String adresseMail { get; set; }
    public String motDePasse { get; set; }
}