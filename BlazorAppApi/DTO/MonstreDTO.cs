using System.ComponentModel.DataAnnotations;
namespace BlazorAppApi.DTO;

public class MonstreDTO
{
    [Required(ErrorMessage = "Le nom est obligatoire.")]
    [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères.")]
    public string nom { get; set; } = string.Empty;
        
    [Required(ErrorMessage = "La description est obligatoire.")]
    public string description { get; set; } = string.Empty;
    [Required(ErrorMessage = "Le lien de l'image est obligatoire.")]
    public string lienImage { get; set; } = string.Empty;

    [Required(ErrorMessage = "Les points de vies sont obligatoires.")]
    public int pointDeVie { get; set; }

    [Required(ErrorMessage = "Les chances de toucher sont obligatoires.")]
    public double chanceToucher { get; set; }

    [Required(ErrorMessage = "Les points à gagner sont obligatoires.")]
    public double pointGagner { get; set; }

}