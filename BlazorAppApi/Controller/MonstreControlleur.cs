using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;
using BlazorAppApi.DTO;
using BlazorAppApi.Service;

namespace BlazorAppApi.Controller
{

    public class MonstreControlleur(IMonstreService monstreService, ISallesService sallesService) : ControllerBase
    {
        private readonly IMonstreService _monstreService = monstreService;
        private readonly ISallesService _sallesService = sallesService;

        [HttpPost("ajouterMonstre")]
        public async Task<Monstre> CreationeMonstre([FromBody] MonstreDTO MonstreDTO)
        {
            var nouveauMonstre = new Monstre()
            {
                nom =  MonstreDTO.nom,
                description = MonstreDTO.description,  
                lienImage = MonstreDTO.lienImage,
                pointDeVie = MonstreDTO.pointDeVie,
                chanceToucher =  MonstreDTO.chanceToucher,
                pointGagner = MonstreDTO.pointGagner,

                
            };
            await _monstreService.CreationMonstre(nouveauMonstre);
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