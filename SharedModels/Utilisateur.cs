using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace SharedModels;

public class Utilisateur
{
    public int utilisateurId { get; set; }
    [JsonIgnore]
    public Administrateur? administrateur { get; set; }
    [JsonIgnore]
    public Joueur? joueur { get; set; }
    public required String nom { get; set; }
    public required String prenom { get; set; }
    public required String adresseMail { get; set; }
    public required String motDePasse { get; set; }
    public Boolean estActive { get; set; } = true;
}