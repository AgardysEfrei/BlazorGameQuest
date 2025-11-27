using SharedModels;
namespace BlazorAppApi.Service;

public interface IAdministrateurService
{
    public Task<Administrateur> CreationAdministrateur(Administrateur administrateur);
}