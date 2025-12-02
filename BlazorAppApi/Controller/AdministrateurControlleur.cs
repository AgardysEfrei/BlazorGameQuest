using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;
using BlazorAppApi.DTO;
using BlazorAppApi.Service;

namespace BlazorAppApi.Controller
{   [Route("api/[controller]")]
    [ApiController]
    public class AdministrateurControlleur(IAdministrateurService administrateurService) : ControllerBase
    {
        private readonly IAdministrateurService _administrateurService = administrateurService;

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
            return _administrateurService.TrouverAdministrateurParId(id);
        }

        [HttpGet("trouvertouslesAdministrateurs")]
        public List<Administrateur> TrouverTousLesAdministrateurs()
        {
            return _administrateurService.TrouverTousLesAdministrateurs();
        }

    }
}