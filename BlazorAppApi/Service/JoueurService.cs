using BlazorAppApi.Controller;
using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;

namespace BlazorAppApi.Service;

public class JoueurService : IJoueurService
{
    private readonly BlazorQuestDbContext _context;
    private readonly IUtilisateurService _utilisateurService;

    public JoueurService(BlazorQuestDbContext context, IUtilisateurService utilisateurService)
    {
        _context = context;
        _utilisateurService = utilisateurService;
    }

    public async Task<Joueur> CreationJoueur(Joueur joueur)
    {
        Utilisateur? utilisateurAAjouter = _utilisateurService.TrouverUtilisateurParId(joueur.utilisateurId);
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
    public Joueur TrouverJoueurParId(int id)
    {
        Joueur? JoueurAppele = _context.Joueurs.Find(id);
        JoueurAppele!.utilisateur = _utilisateurService.TrouverUtilisateurParId(JoueurAppele.utilisateurId);
        if (JoueurAppele == null)
            throw new BadHttpRequestException("Aucun Joueur trouve");
        JoueurAppele.score = _context.ScoreParties.Where(p => p.joueurId == id).ToList();
        return JoueurAppele;
    }
    
    public List<Joueur> TrouverTousLesJoueurs()
    {
        List<Joueur> listeDesIdJoueurs = _context.Joueurs.ToList();
        List<Joueur> listeDesJoueurs = new List<Joueur>();
        foreach (var joueur in listeDesIdJoueurs)
        {
            listeDesJoueurs.Add(TrouverJoueurParId(joueur.joueurid));
        }
        return listeDesJoueurs;
    }

    public double CalculerScoreTotal(int id)
    {
        var joueurActuel = TrouverJoueurParId(id);
        double scoreTotal = joueurActuel.score.Sum(partie => partie.score);
        return scoreTotal;

    }
}