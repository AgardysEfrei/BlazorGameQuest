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
    public class ScorePartieControlleur
    {
        private readonly IScorePartieService _scorePartieService;
        public ScorePartieControlleur(IScorePartieService scorePartieService)
        {
            _scorePartieService = scorePartieService;
        }
        
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
    }
}