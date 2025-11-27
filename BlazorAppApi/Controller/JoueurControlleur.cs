using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using BlazorAppApi.DTO;
namespace BlazorAppApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoueurControlleur
    {
        private readonly BlazorQuestDbContext _context;
        public JoueurControlleur(BlazorQuestDbContext context)
        {
            _context = context;
        }

        [HttpPost("ajouterJoueur")]
        public async Task<ActionResult<Joueur>> CreationeJoueur([FromBody] JoueurDTO JoueurDTO)
        {
            Utilisateur? utilisateurAAjouter = _context.Find<Utilisateur>(JoueurDTO.utilisateurId);
            if (utilisateurAAjouter == null)
                throw new BadHttpRequestException("Aucun utilisateur trouve");
            var nouvelJoueur = new Joueur()
            {
                utilisateurId =  JoueurDTO.utilisateurId,
                utilisateur =  utilisateurAAjouter
                
            };
            utilisateurAAjouter.joueur = nouvelJoueur;
            _context.Update(utilisateurAAjouter);
            _context.Joueurs.Add(nouvelJoueur);
            await _context.SaveChangesAsync();
            return nouvelJoueur;
        }

        [HttpGet("trouverJoueur/{id}")]
        public SharedModels.Joueur TrouverJoueurParId(int id)
        {
            Joueur? JoueurAppele = _context.Joueurs.Find(id);
            if (JoueurAppele == null)
                throw new BadHttpRequestException("Aucun Joueur trouve");
            return JoueurAppele;
        }

        [HttpGet("trouvertouslesJoueurs")]
        public List<Joueur> TrouverTousLesJoueurs()
        {
            return _context.Joueurs.ToList();
        }
    }
}