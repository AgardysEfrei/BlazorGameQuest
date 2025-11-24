using System.Diagnostics.CodeAnalysis;
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
        public SallesControlleur(BlazorQuestDbContext context)
        {
            _context = context;
        }
        [HttpPost("genererunesallevide")]
        public async Task<ActionResult<Salles>> CreationeSalles()
        {
            var nouvelleSalle = new Salles();
            _context.SallesEnumerable.Add(nouvelleSalle);
            await _context.SaveChangesAsync();
            return nouvelleSalle;
        }
        [HttpGet("trouvertouteslesSalles")]
        public List<Salles> TrouverTousLesSalles()
        {
            return _context.SallesEnumerable.ToList();
        }
    }
}