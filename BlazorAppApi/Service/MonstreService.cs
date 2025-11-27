using System.Security.Cryptography;
using SharedModelDbContext;
using SharedModels;
namespace BlazorAppApi.Service;

public class MonstreService : IMonstreService
{
    BlazorQuestDbContext _context;

    public MonstreService(BlazorQuestDbContext context)
    {
        _context = context;
    }

    public async Task<Monstre> CreationMonstre(Monstre monstre)
    {
        var nouveauMonstre = new Monstre()
        {
            nom = monstre.nom,
            description = monstre.description,

        };
        _context.Monstres.Add(nouveauMonstre);
        await _context.SaveChangesAsync();
        return nouveauMonstre;
    }
    
    public SharedModels.Monstre TrouverMonstreParId(int id)
    {
        Monstre MonstreAppele = _context.Monstres.Find(id);
        if (MonstreAppele == null)
            throw new BadHttpRequestException("Aucun Monstre trouve");
        return MonstreAppele;
    }
    public List<Monstre> TrouverTousLesMonstres()
    {
        return _context.Monstres.ToList();
    }
}