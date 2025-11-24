using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;
using BlazorAppApi.DTO;
namespace BlazorAppApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScorePartieControlleur
    {
        private readonly BlazorQuestDbContext _context;
        public ScorePartieControlleur(BlazorQuestDbContext context)
        {
            _context = context;
        }

        [HttpPost("ajouterScorePartie")]
        public async Task<ActionResult<ScorePartie>> CreationScorePartie([FromBody] ScorePartieDTO ScorePartieDTO)
        {
            Joueur JoueurAAjouter = _context.Find<Joueur>(ScorePartieDTO.joueurId);
            if (JoueurAAjouter == null)
                throw new BadHttpRequestException("Aucun joueur trouve");
            var nouvelScorePartie = new ScorePartie()
            {
                joueurId =  ScorePartieDTO.joueurId,
                joueur = JoueurAAjouter,
                score =  0
                
            };
            JoueurAAjouter.score = nouvelScorePartie;
            _context.Update(JoueurAAjouter);
            _context.ScoreParties.Add(nouvelScorePartie);
            await _context.SaveChangesAsync();
            return nouvelScorePartie;
        }

        [HttpGet("trouverScorePartie/{id}")]
        public SharedModels.ScorePartie TrouverScorePartieParId(int id)
        {
            ScorePartie ScorePartieAppele = _context.ScoreParties.Find(id);
            if (ScorePartieAppele == null)
                throw new BadHttpRequestException("Aucun ScorePartie trouve");
            return ScorePartieAppele;
        }

        [HttpGet("trouvertouslesScoreParties")]
        public List<ScorePartie> TrouverTousLesScoreParties()
        {
            return _context.ScoreParties.ToList();
        }
    }
}