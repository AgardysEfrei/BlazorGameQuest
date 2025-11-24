using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;
using BlazorAppApi.DTO;

namespace BlazorAppApi.Controller
{

    public class MonstreControlleur : ControllerBase
    {
        private readonly BlazorQuestDbContext _context;
        public MonstreControlleur(BlazorQuestDbContext context)
        {
            _context = context;
        }

        [HttpPost("ajouterMonstre")]
        public async Task<ActionResult<Monstre>> CreationeMonstre([FromBody] MonstreDTO MonstreDTO)
        {
            var nouveauMonstre = new Monstre()
            {
                nom =  MonstreDTO.nom,
                description = MonstreDTO.description,  
                
            };
            _context.Monstres.Add(nouveauMonstre);
            await _context.SaveChangesAsync();
            return nouveauMonstre;
        }

        [HttpGet("trouverMonstre/{id}")]
        public SharedModels.Monstre TrouverMonstreParId(int id)
        {
            Monstre MonstreAppele = _context.Monstres.Find(id);
            if (MonstreAppele == null)
                throw new BadHttpRequestException("Aucun Monstre trouve");
            return MonstreAppele;
        }

        [HttpGet("trouvertouslesMonstres")]
        public List<Monstre> TrouverTousLesMonstres()
        {
            return _context.Monstres.ToList();
        }
    }
}