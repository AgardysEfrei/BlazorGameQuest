using SharedModels;
namespace BlazorAppApi.Service;

public interface IDonjonsService
{
    public Task<Donjons> CreationDonjons();
    public List<Donjons> TrouverTousLesDonjons();
}