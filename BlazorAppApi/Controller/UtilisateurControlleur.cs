using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;
using BlazorAppApi.DTO;
using BlazorAppApi.Service;

namespace BlazorAppApi.Controller
{   [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurControlleur(IUtilisateurService utilisateurService) : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService = utilisateurService;
        [HttpPost("ajouterutilisateur")]
        public Task<Utilisateur> CreationUtilisateur([FromBody] UtilisateurDTO utilisateurDTO)
        {
            Utilisateur utilisateur = new Utilisateur()
            {
                nom = utilisateurDTO.nom,
                prenom =  utilisateurDTO.prenom,
                adresseMail =  utilisateurDTO.adresseMail,
                motDePasse =   utilisateurDTO.motDePasse,
            };
            return _utilisateurService.CreationUtilisateur(utilisateur);
        }

        [HttpGet("trouverutilisateur/{id}")]
        public SharedModels.Utilisateur TrouverUtilisateurParId(int id)
        {
            return _utilisateurService.TrouverUtilisateurParId(id);
        }

        [HttpGet("trouvertouslesutilisateurs")]
        public List<Utilisateur> TrouverTousLesUtilisateurs()
        {
            return _utilisateurService.TrouverTousLesUtilisateurs();
        }

        [HttpPatch("desactiverUtilisateur/{id}")]
        public void DesactiverUtilisateur(int id)
        { 
            _utilisateurService.DesactiverUtilisateur(id);
        }

        [HttpPatch("reactiverUtilisateur/{id}")]
        public void ReactiverUtilisateur(int id)
        {
            _utilisateurService.ReactiverUtilisateur(id);
        }
    }
}