using SharedModels;
namespace BlazorAppApi.Service;

public interface IMonstreService
{
    public Task<Monstre> CreationMonstre(Monstre monstre);
    public Monstre TrouverMonstreParId(int id);
    public List<Monstre> TrouverTousLesMonstres();
    public Monstre ChargerMonstreDeLaSalle(Salles salleDuMonstre);
}