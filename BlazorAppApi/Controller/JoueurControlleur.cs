using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using BlazorAppApi.DTO;
using BlazorAppApi.Service;

namespace BlazorAppApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoueurControlleur
    {
        private readonly BlazorQuestDbContext _context;
        private readonly IJoueurService _joueurService;
        public JoueurControlleur(BlazorQuestDbContext context, IJoueurService joueurService)
        {
            _context = context;
            _joueurService = joueurService;
        }

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
            return _joueurService.TrouverTousLesJoueurs();
        }
    }
}