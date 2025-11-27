using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;
using BlazorAppApi.DTO;
using BlazorAppApi.Service;

namespace BlazorAppApi.Controller
{   [Route("api/[controller]")]
    [ApiController]
    public class AdministrateurControlleur : ControllerBase
    {
        private readonly BlazorQuestDbContext _context;
        private readonly IAdministrateurService _administrateurService;
        public AdministrateurControlleur(BlazorQuestDbContext context, IAdministrateurService administrateurService)
        {
            _context = context;
            _administrateurService = administrateurService;
        }
        [HttpPost("ajouterAdministrateur")]
        public Task<Administrateur> CreationeAdministrateur([FromBody] AdministrateurDTO AdministrateurDTO)
        {
            var nouvelleAdministrateur = new Administrateur()
            {
                utilisateurId =  AdministrateurDTO.utilisateurId,
            };
            return _administrateurService.CreationAdministrateur(nouvelleAdministrateur);
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