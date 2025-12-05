using SharedModels;
namespace BlazorAppApi.Service;

public interface IDonjonsService
{
    public Task<Donjons> CreationDonjons();
    public List<Donjons> TrouverTousLesDonjons();
    public Task<Donjons> TrouverDonjon(int IdDonjon);
}