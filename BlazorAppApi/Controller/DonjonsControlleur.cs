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

    public class DonjonsControlleur : ControllerBase
    {
        private readonly BlazorQuestDbContext _context;
        private readonly IDonjonsService _donjonsService;
        public DonjonsControlleur(BlazorQuestDbContext context, IDonjonsService donjonsService)
        {
            _context = context;
            _donjonsService = donjonsService;
        }
        [HttpPost("genererundonjon")]
        public Task<Donjons> CreationeDonjons()
        {
            return _donjonsService.CreationDonjons();
        }
        [HttpGet("trouvertouslesdonjons")]
        public List<Donjons> TrouverTousLesDonjons()
        {
            return _donjonsService.TrouverTousLesDonjons();
        }
    }
}