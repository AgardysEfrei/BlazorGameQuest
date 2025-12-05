namespace BlazorAppApi.Service;
using System.Security.Cryptography;
using SharedModelDbContext;
using SharedModels;
public class SallesService : ISallesService
{
    private readonly BlazorQuestDbContext _context;
    private readonly IMonstreService _monstreservice;

    public SallesService(BlazorQuestDbContext context,IMonstreService monstreservice)
    {
        _monstreservice = monstreservice;
        _context = context;
    }
    

    
    public async Task<Salles> CreationSalles()
    {
        var nouvelleSalle = new Salles();
        _context.Salles.Add(nouvelleSalle);
        await _context.SaveChangesAsync();
        return nouvelleSalle;
    }

    public Salles TrouverSalle(int idSalle)
    {
        Salles? salleCherche = _context.Salles.Find(idSalle);
        if (salleCherche == null)
        {
            throw new BadHttpRequestException("Aucune salle trouvee");
        }
        salleCherche.monstre= _monstreservice.TrouverMonstreParId(salleCherche.monstreId);
        return salleCherche ;
    }
    
    public List<Salles> TrouverToutesLesSalles()
    {
        return _context.Salles.ToList();
    }
}