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

    public class SallesControlleur : ControllerBase
    {
        private readonly BlazorQuestDbContext _context;
        private readonly ISallesService _sallesService;
        public SallesControlleur(BlazorQuestDbContext context, ISallesService sallesService)
        {
            _context = context;
            _sallesService = sallesService;
        }
        [HttpPost("genererunesallevide")]
        public Task<Salles> CreationeSalles()
        {
            return _sallesService.CreationSalles();
        }
        [HttpGet("trouvertouteslesSalles")]
        public List<Salles> TrouverTousLesSalles()
        {
            return _sallesService.TrouverToutesLesSalles();
        }
    }
}