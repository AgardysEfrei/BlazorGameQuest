using BlazorAppApi.Controller;
using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
namespace BlazorAppApi.Service;

public class DonjonsService : IDonjonsService
{
    private readonly BlazorQuestDbContext _context;
    public DonjonsService(BlazorQuestDbContext context)
    {
        _context = context;
    }

    public async Task<Donjons> CreationDonjons()
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

    public List<Donjons> TrouverTousLesDonjons()
    {
        return _context.DonjonsEnumerable.ToList();
    }
}