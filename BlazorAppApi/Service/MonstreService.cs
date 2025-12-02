using System.Security.Cryptography;
using SharedModelDbContext;
using SharedModels;
namespace BlazorAppApi.Service;

public class MonstreService : IMonstreService
{
    BlazorQuestDbContext _context;
    ISallesService _salles;

    public MonstreService(BlazorQuestDbContext context, ISallesService salles)
    {
        _context = context;
        _salles = salles;
    }

    public async Task<Monstre> CreationMonstre(Monstre monstre)
    {
        var nouveauMonstre = new Monstre()
        {
            nom = monstre.nom,
            description = monstre.description,
            lienImage = monstre.lienImage,
            pointDeVie = monstre.pointDeVie,
            chanceToucher =  monstre.chanceToucher,
            pointGagner = monstre.pointGagner,

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

    public Monstre ChargerMonstreDeLaSalle(Salles salleDuMonstre)
    {
        Monstre monstreDeLaSalle = TrouverMonstreParId(salleDuMonstre.monstreId);
        //On ne charge que si la salle n'a pas encore le monstre chargé
        if (salleDuMonstre.monstre == null)
        {
            salleDuMonstre.monstre =  TrouverMonstreParId(monstreDeLaSalle.monstreid);
        }
        _context.Update(salleDuMonstre);
        return  monstreDeLaSalle;
    }
}