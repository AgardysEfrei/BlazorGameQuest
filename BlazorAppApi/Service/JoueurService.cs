using BlazorAppApi.Controller;
using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;
using SharedModelDbContext;

namespace BlazorAppApi.Service;

public class JoueurService : IJoueurService
{
    private readonly BlazorQuestDbContext _context;
    private readonly IUtilisateurService _utilisateurService;

    public JoueurService(BlazorQuestDbContext context, IUtilisateurService utilisateurService)
    {
        context = context;
        _utilisateurService = utilisateurService;
    }

    public async Task<Joueur> CreationJoueur(Joueur joueur)
    {
        Utilisateur utilisateurAAjouter = _utilisateurService.TrouverUtilisateurParId(joueur.utilisateurId);
        if (utilisateurAAjouter == null)
            throw new BadHttpRequestException("Aucun utilisateur trouve");
        var nouvelJoueur = new Joueur()
        {
            utilisateurId =  utilisateurAAjouter.utilisateurId,
            utilisateur =  utilisateurAAjouter
                
        };
        utilisateurAAjouter.joueur = nouvelJoueur;
        _context.Update(utilisateurAAjouter);
        _context.Joueurs.Add(nouvelJoueur);
        await _context.SaveChangesAsync();
        return nouvelJoueur;
    }
    
    [HttpGet("trouverJoueur/{id}")]
    public Joueur TrouverJoueurParId(int id)
    {
        Joueur JoueurAppele = _context.Joueurs.Find(id);
        if (JoueurAppele == null)
            throw new BadHttpRequestException("Aucun Joueur trouve");
        return JoueurAppele;
    }
    
    public List<Joueur> TrouverTousLesJoueurs()
    {
        return _context.Joueurs.ToList();
    }
}