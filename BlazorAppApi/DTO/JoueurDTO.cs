using System.ComponentModel.DataAnnotations;
using SharedModels;

namespace BlazorAppApi.DTO
{
    public class JoueurDTO
    {
        [Required(ErrorMessage = "L'ID utilisateur est obligatoire.")]
        public int utilisateurId { get; set; }
    }
}