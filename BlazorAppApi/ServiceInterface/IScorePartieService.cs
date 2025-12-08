using SharedModels;

namespace BlazorAppApi.Service;

public interface IScorePartieService
{
    public Task<ScorePartie> TrouverScorePartieParId(int id);
    public List<ScorePartie> TrouverTousLesScorePartie();
    public List<ScorePartie> TrouverTousLesScorePartieParIdJoueur(int id);
    public Task<ScorePartie> GenererNouvellePartie(int id);
    public Task<double> FouillerPiece(ScorePartie partieEnCours);
    public Task<int> InfligerDegats(ScorePartie partieEnCours);
    public Task<bool> SauvegarderPartie(ScorePartie partieEnCours);
    

}