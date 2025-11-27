using BlazorAppApi.Controller;
using Microsoft.AspNetCore.Mvc;
using SharedModelDbContext;
using SharedModels;

namespace BlazorAppApi.Service;

public class ScorePartieService : IScorePartieService
{
    private readonly BlazorQuestDbContext _context;
    public ScorePartieService(BlazorQuestDbContext context)
    {
        _context = context;
    }

    public ScorePartie TrouverScorePartieParId(int id)
    {
        ScorePartie ScorePartieAppele = _context.ScoreParties.Find(id);
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
        var donjonController = new DonjonsControlleur(_context);
        var donjonGenere = (await donjonController.CreationeDonjons()).Value;
        var nouvellePartie = new ScorePartie()
        {
            joueurId = id,
            joueur = _context.Joueurs.Find(id),
            donjonGenere = donjonGenere,
        };
        _context.ScoreParties.Add(nouvellePartie);
        await _context.SaveChangesAsync();
        donjonGenere.scorePartie = nouvellePartie;
        donjonGenere.scorePartieid = nouvellePartie.ScorePartieId;
        _context.DonjonsEnumerable.Update(donjonGenere);
        await _context.SaveChangesAsync();
        return nouvellePartie;
    }
}