using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;
using BlazorAppApi.DTO;
namespace BlazorAppApi.Controller
{   [Route("api/[controller]")]
    [ApiController]
    public class AdministrateurControlleur : ControllerBase
    {
        private readonly BlazorQuestDbContext _context;
        public AdministrateurControlleur(BlazorQuestDbContext context)
        {
            _context = context;
        }

        [HttpPost("ajouterAdministrateur")]
        public async Task<ActionResult<Administrateur>> CreationeAdministrateur([FromBody] AdministrateurDTO AdministrateurDTO)
        {
            Utilisateur utilisateurAAjouter = _context.Find<Utilisateur>(AdministrateurDTO.utilisateurId);
            if (utilisateurAAjouter == null)
                throw new BadHttpRequestException("Aucun utilisateur trouve");
            var nouvelAdministrateur = new Administrateur()
            {
                utilisateurId =  AdministrateurDTO.utilisateurId,
                utilisateur =  utilisateurAAjouter
                
            };
            utilisateurAAjouter.administrateur = nouvelAdministrateur;
            _context.Update(utilisateurAAjouter);
            _context.Administrateurs.Add(nouvelAdministrateur);
            await _context.SaveChangesAsync();
            return nouvelAdministrateur;
        }

        [HttpGet("trouverAdministrateur/{id}")]
        public SharedModels.Administrateur TrouverAdministrateurParId(int id)
        {
            Administrateur AdministrateurAppele = _context.Administrateurs.Find(id);
            if (AdministrateurAppele == null)
                throw new BadHttpRequestException("Aucun Administrateur trouve");
            return AdministrateurAppele;
        }

        [HttpGet("trouvertouslesAdministrateurs")]
        public List<Administrateur> TrouverTousLesAdministrateurs()
        {
            return _context.Administrateurs.ToList();
        }

    }
}