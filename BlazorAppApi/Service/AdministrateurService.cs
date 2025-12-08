using SharedModels;
using BlazorAppApi.Controller;
using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
namespace BlazorAppApi.Service;

public class AdministrateurService : IAdministrateurService
{
    private readonly BlazorQuestDbContext _context;
    private readonly IUtilisateurService _utilisateurService;
    public AdministrateurService(BlazorQuestDbContext context, IUtilisateurService utilisateurService)
    {
        _context = context;
        _utilisateurService = utilisateurService;
    }

    public async Task<Administrateur> CreationAdministrateur(Administrateur administrateur)
    {
        Utilisateur utilisateurAAjouter = _utilisateurService.TrouverUtilisateurParId(administrateur.utilisateurId);
        if (utilisateurAAjouter == null)
            throw new BadHttpRequestException("Aucun utilisateur trouve");
        var nouvelAdministrateur = new Administrateur()
        {
            utilisateurId =  administrateur.utilisateurId,
            utilisateur =  utilisateurAAjouter
                
        };
        utilisateurAAjouter.administrateur = nouvelAdministrateur;
        _context.Update(utilisateurAAjouter);
        _context.Administrateurs.Add(nouvelAdministrateur);
        await _context.SaveChangesAsync();
        return nouvelAdministrateur;
    }

    public Administrateur TrouverAdministrateurParId(int id)
    {
        Administrateur? AdministrateurAppele = _context.Administrateurs.Find(id);
        if (AdministrateurAppele == null)
            throw new BadHttpRequestException("Aucun Administrateur trouve");
        return AdministrateurAppele;
    }

    public List<Administrateur> TrouverTousLesAdministrateurs()
    {
        return _context.Administrateurs.ToList();
    }
}