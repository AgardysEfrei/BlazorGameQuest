using Microsoft.AspNetCore.Components;
using System.Net;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharedModels;

namespace BlazorApp.Components.Pages;

public partial class Admin : ComponentBase
{
    
    [Inject]
    private IHttpClientFactory? HttpClientFactory { get; set; }
    
    [Inject]
    private NavigationManager? NavigationManager{ get; set; }
    private HttpClient? HttpClient => HttpClientFactory?.CreateClient("Api");
    private List<Joueur>? listeDesJoueurs;
    private bool IsChanging { get; set; } =  false;
    private bool IsLoading { get; set; } = false; //permet d'indiquer si les données sont en train d'être chargées ou non
    
    protected override async Task OnParametersSetAsync()
    {
        await ChargerJoueurs();
    }

    private async Task ChargerJoueurs()
    {
        idAdmin = idUtilisateur;
        IsLoading = true;
        if (HttpClient != null)
            listeDesJoueurs =
                await HttpClient.GetFromJsonAsync<List<SharedModels.Joueur>>(
                    $"api/JoueurControlleur/trouvertouslesJoueurs") ?? new List<Joueur>(); //Changer cette ligne pour la version 4
        else
        {
            throw new HttpRequestException(
                "Erreur lors du chargement des joueurs",
                null,
                HttpStatusCode.BadRequest
            );
        }

        IsLoading = false;
    }

    private async Task DesactiverJoueurs(int idJoueur)
    {
        IsChanging = true;
        await HttpClient.PatchAsync($"api/utilisateurControlleur/desactiverUtilisateur/{idJoueur}", null);
        await ChargerJoueurs();
        StateHasChanged();
        IsChanging = false;
    }
    private async Task ReactiverJoueurs(int idJoueur)
    {
        IsChanging = true;
        await HttpClient.PatchAsync($"api/utilisateurControlleur/reactiverUtilisateur/{idJoueur}",null);
        await ChargerJoueurs();
        StateHasChanged();
        IsChanging = false;
    }
}