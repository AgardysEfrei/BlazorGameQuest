using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharedModels;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Pages;


public partial class Leaderboard : ComponentBase
{
    [Inject]
    private IHttpClientFactory? HttpClientFactory { get; set; }
    [Inject]
    private NavigationManager? NavigationManager { get; set; }
// On obtient le client nommé "API" via la fabrique (configuré dans Program.cs)
    private HttpClient? HttpClient => HttpClientFactory?.CreateClient("Api");
    private List<Joueur> ListeDesJoueurs;
    private bool IsLoading { get; set; } = false;


    protected override async Task OnInitializedAsync()
    {
        await TrouverLesJoueurs();
    }

    private async Task TrouverLesJoueurs()
        {
            IsLoading = true;
            ListeDesJoueurs= new List<Joueur>();
            ListeDesJoueurs = await HttpClient.GetFromJsonAsync<List<Joueur>>($"api/JoueurControlleur/trouvertouslesJoueurs") ?? throw new HttpRequestException(
                        "Erreur lors de la récupération des joueurs", 
                        null, 
                        HttpStatusCode.BadRequest
                    );
            var joueursAvecScoresTasks = ListeDesJoueurs.Select(joueur => new
            {
                Joueur = joueur,
                ScoreTask = CalculerScore(joueur) // Lance l'appel API (Task<double>)
            }).ToList();
            await Task.WhenAll(joueursAvecScoresTasks.Select(x => x.ScoreTask));

            // 3. Tri final : Le tri est maintenant sûr car ScoreTask.Result est un Double résolu.
            ListeDesJoueurs = joueursAvecScoresTasks
                // Tri sur le contenu de la Task (le Double)
                .OrderByDescending(x => x.ScoreTask.Result) 
                // Sélectionne uniquement l'objet Joueur
                .Select(x => x.Joueur) 
                .ToList();
            IsLoading = false;
        }

    private async Task<Double> CalculerScore(Joueur joueurActuel)
    {
        var scoreTotal = await HttpClient!.GetFromJsonAsync<Double>(
            $"api/JoueurControlleur/CalculerScoreJoueur/{joueurActuel.joueurid}");
        return scoreTotal;
    }
    
}