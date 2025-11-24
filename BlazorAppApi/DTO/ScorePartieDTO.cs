using System.ComponentModel.DataAnnotations;
using SharedModels;

namespace BlazorAppApi.DTO
{
    public class ScorePartieDTO
    {
        [Required(ErrorMessage = "L'ID du joueur est obligatoire.")]
        public int joueurId { get; set; }
    }
}