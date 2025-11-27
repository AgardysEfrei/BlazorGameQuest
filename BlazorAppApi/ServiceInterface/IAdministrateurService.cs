using SharedModels;
namespace BlazorAppApi.Service;

public interface IAdministrateurService
{
    public Task<Administrateur> CreationAdministrateur(Administrateur administrateur);
    public Administrateur TrouverAdministrateurParId(int id);
    public List<Administrateur> TrouverTousLesAdministrateurs();
    
}