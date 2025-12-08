using SharedModels;
namespace BlazorAppApi.Service;

public interface IJoueurService
{
    public Task<Joueur> CreationJoueur(Joueur joueur);
    public Joueur TrouverJoueurParId(int id);
    public List<Joueur> TrouverTousLesJoueurs();
    public double CalculerScoreTotal(int id);
}