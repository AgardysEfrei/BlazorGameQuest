using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using Microsoft.EntityFrameworkCore;
using BlazorAppApi.DTO;
using BlazorAppApi.Service;
using static BlazorAppApi.Controller.DonjonsControlleur;
namespace BlazorAppApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScorePartieControlleur(IScorePartieService scorePartieService) : ControllerBase
    {
        private readonly IScorePartieService _scorePartieService =  scorePartieService;
        [HttpGet("trouverScorePartie/{id}")]
        public async Task<ScorePartie> TrouverScorePartieParId(int id)
        {
            return await _scorePartieService.TrouverScorePartieParId(id);
        }
        [IgnoreAntiforgeryToken]
        [HttpPatch("sauvegarderPartie")]
        public async Task<IActionResult> SauvegarderPartie([FromBody] ScorePartie partieRecue)
        {
            Console.WriteLine("je suis dedans\n");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Modele invalide : "+ModelBinderFactory.ToString());
                // This line returns the detailed validation failure information
                return BadRequest(ModelState); 
            }
            await _scorePartieService.SauvegarderPartie(partieRecue);
            // Retourner un statut de succès standard
            return NoContent();
        }

        [HttpGet("trouvertouslesScoreParties")]
        public List<ScorePartie> TrouverTousLesScoreParties()
        {
            return _scorePartieService.TrouverTousLesScorePartie();
        }

        [HttpGet("trouvertouslescoreparties/{id}")]
        public List<ScorePartie> TrouverTousLesScorePartieParIdJoueur(int id)
        {
            return _scorePartieService.TrouverTousLesScorePartieParIdJoueur(id);
        }

        [HttpGet("genererNouvellePartie/{id}")]
        public Task<ScorePartie> GenererNouvellePartie(int id)
        {
            return _scorePartieService.GenererNouvellePartie(id);
        }

        [HttpGet("fouillerPiece/{id}")]
        public async Task<double> FouillerPiece(int id)
        {
            ScorePartie partieEnCours = await TrouverScorePartieParId(id);
            return await _scorePartieService.FouillerPiece(partieEnCours);
        }

        [HttpGet("InfligerDegats/{id}")]
        public async Task<int> InfligerDegats(int id)
        {
            ScorePartie partieEnCours = await TrouverScorePartieParId(id);
            return await _scorePartieService.InfligerDegats(partieEnCours);
        }
        
    }
}