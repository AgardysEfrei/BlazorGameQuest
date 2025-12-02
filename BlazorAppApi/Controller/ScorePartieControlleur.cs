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
        public SharedModels.ScorePartie TrouverScorePartieParId(int id)
        {
            return _scorePartieService.TrouverScorePartieParId(id);
        }

        [HttpGet("trouvertouslesScoreParties")]
        public List<ScorePartie> TrouverTousLesScoreParties()
        {
            return _scorePartieService.TrouverTousLesScorePartie();
        }

        [HttpGet("genererNouvellePartie/{id}")]
        public Task<ScorePartie> GenererNouvellePartie(int id)
        {
            return _scorePartieService.GenererNouvellePartie(id);
        }

        [HttpGet("fouillerPiece/{id}")]
        public double FouillerPiece(int id)
        {
            ScorePartie partieEnCours = TrouverScorePartieParId(id);
            return _scorePartieService.FouillerPiece(partieEnCours);
        }

        [HttpGet("InfligerDegats/{id}")]
        public int InfligerDegats(int id)
        {
            ScorePartie partieEnCours = TrouverScorePartieParId(id);
            return _scorePartieService.InfligerDegats(partieEnCours);
        }

        [HttpGet("ChangerDePieces/{id}")]
        public Boolean ChangerDePieces(int id)
        {
            return _scorePartieService.ChangerDePiece(_scorePartieService.TrouverScorePartieParId(id));
        }
    }
}