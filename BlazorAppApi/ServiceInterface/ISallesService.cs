using SharedModels;
namespace BlazorAppApi.Service;

public interface ISallesService
{
    public Task<Salles> CreationSalles();
    public List<Salles> TrouverToutesLesSalles();
}