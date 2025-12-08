using SharedModels;
using BlazorAppApi.Controller;
using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;

namespace BlazorAppApi.Service;

public class UtilisateurService : IUtilisateurService
{
    private readonly BlazorQuestDbContext _context;
    public UtilisateurService(BlazorQuestDbContext context)
    {
        _context = context;
    }

    public async Task<Utilisateur> CreationUtilisateur(Utilisateur utilisateur)
    {
        var nouvelUtilisateur = new Utilisateur()
        {
            nom = utilisateur.nom,
            prenom = utilisateur.prenom,
            motDePasse = utilisateur.motDePasse,
            adresseMail = utilisateur.adresseMail,
        };
        _context.Utilisateurs.Add(nouvelUtilisateur);
        await _context.SaveChangesAsync();
        return nouvelUtilisateur;
    }

    public Utilisateur TrouverUtilisateurParId(int id)
    {
        Utilisateur? utilisateur = _context.Utilisateurs.Find(id);
        if (utilisateur == null)
            throw new BadHttpRequestException("Aucun utilisateur trouve");
        return utilisateur;
    }
    
    public List<Utilisateur> TrouverTousLesUtilisateurs()
    {
        return _context.Utilisateurs.ToList();
    }

    public async Task DesactiverUtilisateur(int id)
    {
        Utilisateur? utilisateur = TrouverUtilisateurParId(id);
        utilisateur.estActive = false;
        _context.Utilisateurs.Update(utilisateur);
        await _context.SaveChangesAsync();
    }
    public async Task ReactiverUtilisateur(int id)
    {
        Utilisateur? utilisateur = TrouverUtilisateurParId(id);
        utilisateur.estActive = true;
        _context.Utilisateurs.Update(utilisateur);
        await _context.SaveChangesAsync();
    }

}