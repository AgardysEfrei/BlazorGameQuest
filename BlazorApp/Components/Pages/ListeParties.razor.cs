using System.Net;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharedModels;

namespace BlazorApp.Components.Pages;

public partial class ListeParties : ComponentBase
{
    [Inject]
    private IHttpClientFactory? HttpClientFactory { get; set; }
    
    [Inject]
    private NavigationManager? NavigationManager{ get; set; }
    private HttpClient? HttpClient => HttpClientFactory?.CreateClient("Api");
    private List<SharedModels.ScorePartie>? listeDesPartiesEnCours;
    private bool IsLoading { get; set; } = false; //permet d'indiquer si les données sont en train d'être chargées ou non
    
    protected override async Task OnParametersSetAsync()
    {
        await ChargerPartiesEnCours();
    }

    private async Task ChargerPartiesEnCours()
    {
        idJoueur = idUtilisateur;
        IsLoading = true;
        if (HttpClient != null)
            listeDesPartiesEnCours =
                await HttpClient.GetFromJsonAsync<List<SharedModels.ScorePartie>>(
                    $"api/ScorePartieControlleur/trouvertouslescoreparties/{idJoueur}") ?? new List<ScorePartie>(); //Changer cette ligne pour la version 4
        else
        {
            throw new HttpRequestException(
                "Erreur lors du chargement des parties",
                null,
                HttpStatusCode.BadRequest
            );
        }

        IsLoading = false;
    }

    public void SelectionnerPartie(int idPartie)
    {
        NavigationManager?.NavigateTo($"PartieEnCours/{idPartie}");
    }

    public async Task GenererNouvellePartie()
    {
        idJoueur = idUtilisateur;
        ScorePartie? nouvellePartie = await HttpClient.GetFromJsonAsync<SharedModels.ScorePartie>($"api/ScorePartieControlleur/genererNouvellePartie/{idJoueur}");
        if (nouvellePartie != null)
        {
            listeDesPartiesEnCours?.Add(nouvellePartie);
            NavigationManager?.NavigateTo($"PartieEnCours/{nouvellePartie?.ScorePartieId}");
        }
        else
        {
            throw new HttpRequestException(
                "Erreur lors de la génération d'une nouvelle partie", 
                null, 
                HttpStatusCode.BadRequest
            );
        }
    }
}