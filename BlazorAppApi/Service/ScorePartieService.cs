using BlazorAppApi.Controller;
using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;

namespace BlazorAppApi.Service;

public class ScorePartieService : IScorePartieService
{
    private readonly BlazorQuestDbContext _context;
    private readonly IDonjonsService _donjonService;
    private readonly IJoueurService _joueurService;
    public ScorePartieService(BlazorQuestDbContext context, IDonjonsService donjonService, IJoueurService joueurService)
    {
        _context = context;
        _donjonService = donjonService;
        _joueurService =  joueurService;
    }

    public async Task<ScorePartie> TrouverScorePartieParId(int id)
    {
        ScorePartie? ScorePartieAppele = _context.ScoreParties.Find(id);
        if (ScorePartieAppele == null)
            throw new BadHttpRequestException("Aucun ScorePartie trouve");
        ScorePartieAppele.donjonGenere = await _donjonService.TrouverDonjon(ScorePartieAppele.donjonId);
        ScorePartieAppele.joueur = _joueurService.TrouverJoueurParId(ScorePartieAppele.joueurId);
        return ScorePartieAppele;
    }

    public List<ScorePartie> TrouverTousLesScorePartieParIdJoueur(int id)
    {
        List<ScorePartie>? scoreParties = _context.ScoreParties.Where(p => p.joueurId == id).ToList();
        if (scoreParties == null)
            throw new BadHttpRequestException("Aucun ScorePartie trouve");
        return scoreParties;
    }

    public async Task<bool> SauvegarderPartie(ScorePartie partieEnCours)
    {
        var partieOrigine = _context.ScoreParties.Find(partieEnCours.ScorePartieId);
        partieOrigine!.estVaincu = partieEnCours.estVaincu;
        partieOrigine!.aFouille = partieEnCours.aFouille;
        partieOrigine.degatsInfliges = partieEnCours.degatsInfliges;
        partieOrigine.partieTerminee = partieEnCours.partieTerminee;
        partieOrigine.pointsDeVie = partieEnCours.pointsDeVie;
        partieOrigine.progression = partieEnCours.progression;
        partieOrigine.score = partieEnCours.score;
        _context.Update(partieOrigine);
        await _context.SaveChangesAsync();
        return true;
    }

    public List<ScorePartie> TrouverTousLesScorePartie()
    {
        return _context.ScoreParties.ToList();
    }

    public async Task<ScorePartie> GenererNouvellePartie(int id)
    {
        var donjonGenere = (await _donjonService.CreationDonjons());
        var nouvellePartie = new ScorePartie()
        {
            joueurId = id,
            joueur = _context.Joueurs.Find(id),
            donjonId = donjonGenere.donjonsid,
        };
        _context.ScoreParties.Add(nouvellePartie);
        await _context.SaveChangesAsync();
        donjonGenere.scorePartie = nouvellePartie;
        _context.Donjons.Update(donjonGenere);
        await _context.SaveChangesAsync();
        return nouvellePartie;
    }



    public async Task<double> FouillerPiece(ScorePartie partieEnCours)
    {
        partieEnCours.donjonGenere = await _donjonService.TrouverDonjon(partieEnCours.donjonId);
        int pieceEnCours = partieEnCours.progression;
        double scoreBonusDeLaPiece = partieEnCours.donjonGenere.sallesList[pieceEnCours].scoreBonus;
        partieEnCours.score += scoreBonusDeLaPiece;
        return scoreBonusDeLaPiece;
    }

    public async Task<Salles> ChargerSalle(ScorePartie partieEnCours)
    {
        partieEnCours.donjonGenere = await _donjonService.TrouverDonjon(partieEnCours.donjonId);
        var salle = partieEnCours.donjonGenere.sallesList;
        Salles salleEnCours = salle[partieEnCours.progression];
        return salleEnCours;
    }
    
    public async Task<int> InfligerDegats(ScorePartie partieEnCours)
    {
        var rand = new Random();
        partieEnCours.donjonGenere = await _donjonService.TrouverDonjon(partieEnCours.donjonId);
        int pieceEnCours = partieEnCours.progression;
        Monstre monstreEnCours = partieEnCours.donjonGenere.sallesList[pieceEnCours].monstre;
        double probabiliteDeTouche = monstreEnCours.chanceToucher;
        int touche = rand.Next(101);
        //Si la touche est inférieur ou égale à la probabilité de touché alors on touche !
        //Cela permet de rester consistent avec les statistiques.
        int degatsInflige = 0;
        if (touche <= probabiliteDeTouche)
        {
            //Plus on a avancé dans le donjon, plus on fait de dégâts
            //Plus on a de points de vie, plus on fait mal
            degatsInflige=20+(pieceEnCours*5) + (partieEnCours.pointsDeVie*2);
        }
        return degatsInflige;
    }
}