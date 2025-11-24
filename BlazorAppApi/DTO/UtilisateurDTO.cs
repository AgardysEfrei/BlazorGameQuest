using System.ComponentModel.DataAnnotations;

namespace BlazorAppApi.DTO
{
    // DTO utilisé pour recevoir les données lors de la création d'un utilisateur (POST)
    // Il n'inclut pas l'Id, car celui-ci est auto-incrémenté par la base de données.
    public class UtilisateurDTO
    {
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères.")]
        public string nom { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le prénom ne doit pas dépasser 100 caractères.")]
        public string prenom { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "Format d'email invalide.")]
        public string adresseMail { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le mot de passe ne doit pas dépasser 100 caractères.")]
        public string motDePasse { get; set; } = string.Empty;
    }
    /*
    public int utilisateurId { get; set; }
    public Administrateur? administrateur { get; set; }
    public Joueur? joueur { get; set; }
    public String nom { get; set; }
    public String prenom { get; set; }
    public String adresseMail { get; set; }
    public String motDePasse { get; set; }
    */
}