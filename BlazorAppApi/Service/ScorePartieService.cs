using BlazorAppApi.Controller;
using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;

namespace BlazorAppApi.Service;

public class ScorePartieService : IScorePartieService
{
    private readonly BlazorQuestDbContext _context;
    private readonly IDonjonsService _donjonService;
    public ScorePartieService(BlazorQuestDbContext context, IDonjonsService donjonService)
    {
        _context = context;
        _donjonService = donjonService;
    }

    public ScorePartie TrouverScorePartieParId(int id)
    {
        ScorePartie? ScorePartieAppele = _context.ScoreParties.Find(id);
        if (ScorePartieAppele == null)
            throw new BadHttpRequestException("Aucun ScorePartie trouve");
        return ScorePartieAppele;
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

    public Boolean ChangerDePiece(ScorePartie partieEnCours)
    {
        partieEnCours.progression += 1;
        if (partieEnCours.progression > 4)
        {
            partieEnCours.partieTerminee = true;
        }
        _context.ScoreParties.Update(partieEnCours);
        return partieEnCours.partieTerminee;
    }

    public double FouillerPiece(ScorePartie partieEnCours)
    {
        partieEnCours.donjonGenere = _donjonService.TrouverDonjon(partieEnCours.donjonId);
        int pieceEnCours = partieEnCours.progression;
        double scoreBonusDeLaPiece = partieEnCours.donjonGenere.sallesList[pieceEnCours].scoreBonus;
        partieEnCours.score += scoreBonusDeLaPiece;
        return scoreBonusDeLaPiece;
    }

    public Salles ChargerSalle(ScorePartie partieEnCours)
    {
        partieEnCours.donjonGenere = _donjonService.TrouverDonjon(partieEnCours.donjonId);
        var salle = partieEnCours.donjonGenere.sallesList;
        Salles salleEnCours = salle[partieEnCours.progression];
        return salleEnCours;
    }
    
    public int InfligerDegats(ScorePartie partieEnCours)
    {
        var rand = new Random();
        partieEnCours.donjonGenere = _donjonService.TrouverDonjon(partieEnCours.donjonId);
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