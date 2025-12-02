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

    public class DonjonsControlleur(IDonjonsService donjonsService) : ControllerBase
    {
        private readonly IDonjonsService _donjonsService = donjonsService;
        
        [HttpPost("genererundonjon")]
        public Task<Donjons> CreationeDonjons()
        {
            return _donjonsService.CreationDonjons();
        }

        [HttpGet("trouverUnDonjon/{IdDonjon}")]
        public Donjons TrouverUnDonjon(int IdDonjon)
        {
            return _donjonsService.TrouverDonjon(IdDonjon);
        }
        
        [HttpGet("trouvertouslesdonjons")]
        public List<Donjons> TrouverTousLesDonjons()
        {
            return _donjonsService.TrouverTousLesDonjons();
        }
    }
}