using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;
using BlazorAppApi.DTO;
namespace BlazorAppApi.Controller
{   [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurControlleur : ControllerBase
    {
        private readonly BlazorQuestDbContext _context;
        public UtilisateurControlleur(BlazorQuestDbContext context)
        {
            _context = context;
        }

        [HttpPost("ajouterutilisateur")]
        public async Task<ActionResult<Utilisateur>> CreationeUtilisateur([FromBody] UtilisateurDTO utilisateurDTO)
        {
            var nouvelUtilisateur = new Utilisateur()
            {
                nom = utilisateurDTO.nom,
                prenom = utilisateurDTO.prenom,
                motDePasse = utilisateurDTO.motDePasse,
                adresseMail = utilisateurDTO.adresseMail
            };
            _context.Utilisateurs.Add(nouvelUtilisateur);
            await _context.SaveChangesAsync();
            return nouvelUtilisateur;
        }

        [HttpGet("trouverutilisateur/{id}")]
        public SharedModels.Utilisateur TrouverUtilisateurParId(int id)
        {
            Utilisateur utilisateurAppele = _context.Utilisateurs.Find(id);
            if (utilisateurAppele == null)
                throw new BadHttpRequestException("Aucun utilisateur trouve");
            return utilisateurAppele;
        }

        [HttpGet("trouvertouslesutilisateurs")]
        public List<Utilisateur> TrouverTousLesUtilisateurs()
        {
            return _context.Utilisateurs.ToList();
        }

    }
}