using System.ComponentModel.DataAnnotations;
namespace BlazorAppApi.DTO;

public class MonstreDTO
{
    [Required(ErrorMessage = "Le nom est obligatoire.")]
    [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères.")]
    public string nom { get; set; } = string.Empty;
        
    [Required(ErrorMessage = "La description est obligatoire.")]
    public string description { get; set; } = string.Empty;

}