using SharedModels;

namespace BlazorAppApi.Service;

public interface IScorePartieService
{
    public ScorePartie TrouverScorePartieParId(int id);
    public List<ScorePartie> TrouverTousLesScorePartie();
    public Task<ScorePartie> GenererNouvellePartie(int id);
}