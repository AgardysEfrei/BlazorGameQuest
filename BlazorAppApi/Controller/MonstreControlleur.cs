using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;
using BlazorAppApi.DTO;
using BlazorAppApi.Service;

namespace BlazorAppApi.Controller
{

    public class MonstreControlleur : ControllerBase
    {
        private readonly BlazorQuestDbContext _context;
        private readonly IMonstreService _monstreService;
        public MonstreControlleur(BlazorQuestDbContext context, IMonstreService monstreService)
        {
            _context = context;
            _monstreService = monstreService;
        }

        [HttpPost("ajouterMonstre")]
        public async Task<Monstre> CreationeMonstre([FromBody] MonstreDTO MonstreDTO)
        {
            var nouveauMonstre = new Monstre()
            {
                nom =  MonstreDTO.nom,
                description = MonstreDTO.description,  
                
            };
            _monstreService.CreationMonstre(nouveauMonstre);
            return nouveauMonstre;
        }

        [HttpGet("trouverMonstre/{id}")]
        public SharedModels.Monstre TrouverMonstreParId(int id)
        {
            return  _monstreService.TrouverMonstreParId(id);
        }

        [HttpGet("trouvertouslesMonstres")]
        public List<Monstre> TrouverTousLesMonstres()
        {
            return _monstreService.TrouverTousLesMonstres();
        }
    }
}