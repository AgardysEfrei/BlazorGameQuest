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
        [HttpPost("genererundonjon")]
        public async Task<ActionResult<Donjons>> CreationeDonjons()
        {
            var nombreAleatoire = new Random();
            var listeSalleAleatoire = _context.SallesEnumerable.ToList();
            //Le but ici est de généré 5 chiffres aléatoires sans qu'il y ai de répétition
            var numeroDesSallesGeneresNonRepetes = Enumerable.Range(0,listeSalleAleatoire.Count).OrderBy(x => nombreAleatoire.Next()).Take(5).ToList();
            List<Salles> sallesTiresAuSort = new List<Salles>();
            for (int indiceSalle = 0; indiceSalle < 5; indiceSalle++)
            {
                var numeroSalleTiree = numeroDesSallesGeneresNonRepetes[indiceSalle];
                sallesTiresAuSort.Add(listeSalleAleatoire[numeroSalleTiree]);
            }
            var nouveauDonjon = new Donjons()
            {
                sallesList =  sallesTiresAuSort,
            };
            return nouveauDonjon;
        }
        [HttpGet("trouvertouslesdonjons")]
        public List<Donjons> TrouverTousLesDonjons()
        {
            return _context.DonjonsEnumerable.ToList();
        }
    }
}