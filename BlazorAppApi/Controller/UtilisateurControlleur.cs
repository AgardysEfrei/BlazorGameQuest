using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;
using BlazorAppApi.DTO;
using BlazorAppApi.Service;

namespace BlazorAppApi.Controller
{   [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurControlleur : ControllerBase
    {
        private readonly BlazorQuestDbContext _context;
        private readonly IUtilisateurService _utilisateurService;
        public UtilisateurControlleur(BlazorQuestDbContext context, UtilisateurService utilisateurService)
        {
            _context = context;
            _utilisateurService = utilisateurService;
        }

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
            return TrouverUtilisateurParId(id);
        }

        [HttpGet("trouvertouslesutilisateurs")]
        public List<Utilisateur> TrouverTousLesUtilisateurs()
        {
            return TrouverTousLesUtilisateurs();
        }

    }
}