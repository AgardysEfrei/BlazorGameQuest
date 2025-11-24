
using System.ComponentModel.DataAnnotations;
using SharedModels;

namespace BlazorAppApi.DTO
{
    public class AdministrateurDTO
    {
        [Required(ErrorMessage = "L'ID utilisateur est obligatoire.")]
        public int utilisateurId { get; set; }
    }
}