namespace BlazorAppApi.Service;
using System.Security.Cryptography;
using SharedModelDbContext;
using SharedModels;
public class SallesService : ISallesService
{
    private readonly BlazorQuestDbContext _context;

    public SallesService(BlazorQuestDbContext context)
    {
        _context = context;
    }
    public async Task<Salles> CreationSalles()
    {
        var nouvelleSalle = new Salles();
        _context.SallesEnumerable.Add(nouvelleSalle);
        await _context.SaveChangesAsync();
        return nouvelleSalle;
    }
    
    public List<Salles> TrouverToutesLesSalles()
    {
        return _context.SallesEnumerable.ToList();
    }
}