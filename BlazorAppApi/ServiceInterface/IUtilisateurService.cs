using SharedModels;
namespace BlazorAppApi.Service;

public interface IUtilisateurService
{
    public Task<Utilisateur> CreationUtilisateur(Utilisateur utilisateur);
    public Utilisateur TrouverUtilisateurParId(int id);
    public List<Utilisateur> TrouverTousLesUtilisateurs();
    public Task DesactiverUtilisateur(int id);
    public Task ReactiverUtilisateur(int id);
}