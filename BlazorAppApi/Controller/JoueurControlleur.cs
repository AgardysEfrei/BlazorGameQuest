using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using BlazorAppApi.DTO;
using BlazorAppApi.Service;

namespace BlazorAppApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoueurControlleur(IJoueurService joueurService) : ControllerBase
    {
        private readonly IJoueurService _joueurService = joueurService;

        [HttpPost("ajouterJoueur")]
        public Task<Joueur> CreationeJoueur([FromBody] JoueurDTO joueurDTO)
        {
            Joueur nouveauJoueurAAjouter = new Joueur()
            {
                utilisateurId = joueurDTO.utilisateurId
            };
            return _joueurService.CreationJoueur(nouveauJoueurAAjouter);
        }

        [HttpGet("trouverJoueur/{id}")]
        public SharedModels.Joueur TrouverJoueurParId(int id)
        {
            return _joueurService.TrouverJoueurParId(id);
        }

        [HttpGet("trouvertouslesJoueurs")]
        public List<Joueur> TrouverTousLesJoueurs()
        {
            List<Joueur> resultat = _joueurService.TrouverTousLesJoueurs(); 
            return resultat;
        }

        [HttpGet("CalculerScoreJoueur/{id}")]
        public Double CalculerScoreJoueur(int id)
        {
            return _joueurService.CalculerScoreTotal(id);
        }
    }
}