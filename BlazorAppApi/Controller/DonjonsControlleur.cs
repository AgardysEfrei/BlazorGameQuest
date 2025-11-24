using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class DonjonsControlleur : ControllerBase
    {
        private readonly BlazorQuestDbContext _context;
        public DonjonsControlleur(BlazorQuestDbContext context)
        {
            _context = context;
        }
        [HttpPost("genererundonjonvide")]
        public async Task<ActionResult<Donjons>> CreationeDonjons()
        {
            var nouveauDonjon = new Donjons();
            _context.DonjonsEnumerable.Add(nouveauDonjon);
            await _context.SaveChangesAsync();
            return nouveauDonjon;
        }
        [HttpGet("trouvertouslesdonjons")]
        public List<Donjons> TrouverTousLesDonjons()
        {
            return _context.DonjonsEnumerable.ToList();
        }
    }
}