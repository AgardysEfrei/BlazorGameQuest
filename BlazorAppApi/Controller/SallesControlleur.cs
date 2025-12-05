using System.Diagnostics.CodeAnalysis;
using BlazorAppApi.Service;
using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class SallesControlleur(ISallesService sallesService) : ControllerBase
    {
        private readonly ISallesService _sallesService = sallesService;
        [HttpPost("genererunesallevide")]
        public Task<Salles> CreationeSalles()
        {
            return _sallesService.CreationSalles();
        }

        [HttpGet("trouverUneSalle/{idSalle}")]
        public Salles TrouverUneSalle(int idSalle)
        {
            return _sallesService.TrouverSalle(idSalle);
        }
        
        [HttpGet("trouvertouteslesSalles")]
        public List<Salles> TrouverTousLesSalles()
        {
            return _sallesService.TrouverToutesLesSalles();
        }
    }
}