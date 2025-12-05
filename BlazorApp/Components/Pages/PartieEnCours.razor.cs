using Microsoft.AspNetCore.Components;
using System.Net;
using SharedModels;
namespace BlazorApp.Components.Pages;

public partial class PartieEnCours : ComponentBase
{
    [Inject]
    private IHttpClientFactory? HttpClientFactory { get; set; }
    [Inject]
    private NavigationManager? NavigationManager { get; set; }
    // On obtient le client nommé "API" via la fabrique (configuré dans Program.cs)
    private HttpClient? HttpClient => HttpClientFactory?.CreateClient("Api");
    private ScorePartie? partieActuelle;
    private Salles? salleEnCours;
    private bool IsLoading { get; set; } = false;
    

    protected override async Task OnInitializedAsync()
    {
        // L'IdPartie est automatiquement rempli par le framework Blazor ici
        await ChargerPartie();
    }

    private async Task<bool> Attaquer(int pvMonstre, double pointsAGagner)
    {
        message = "Vous avez attaqué le monstre !, ";
        StateHasChanged();
        var degatInflige = await HttpClient!.GetFromJsonAsync<int>($"api/ScorePartieControlleur/InfligerDegats/{idPartieEnCours}");
        if (degatInflige > 0)
        {
            message += "et vous l'avez touché !";
            StateHasChanged();
        }
        else
        {
            message += "mais vous l'avez manqué!";
            StateHasChanged();
        }
        partieActuelle!.degatsInfliges+= degatInflige;
        await Task.Delay(2000);
        if (partieActuelle.degatsInfliges >= pvMonstre)
        {
            message = "Vous avez vaincu le monstre !";
            StateHasChanged();
            await Task.Delay(2000);
            partieActuelle.estVaincu = true;
            partieActuelle.score+=pointsAGagner;
            await SauvegarderPartie();
            StateHasChanged();
            return true;
            
        }
        //Le monstre attaque ici, pour simuler une attaque, on regarde si les dégâts qu'il fait sont différents de 0, si c'est le cas, alors on est touché
        else
        {
            degatInflige = await HttpClient!.GetFromJsonAsync<int>($"api/ScorePartieControlleur/InfligerDegats/{idPartieEnCours}");
            message = "Le monstre contre-attaque ! ";
            StateHasChanged();
            if (degatInflige > 0)
            {
                message += "Et vous touche ! Vous perdez 1 point de vie";
                StateHasChanged();
                partieActuelle.pointsDeVie -= 1;
                await SauvegarderPartie();
                await Task.Delay(2000);
            }
            else
            {
                message += "Et vous rate ! Quelle chance !";
                StateHasChanged();
                await Task.Delay(2000);
            }

            if (partieActuelle.pointsDeVie <= 0)
            {
                message = "Vous n'avez plus de points de vie ! GAME OVER";
                partieActuelle.score = 0;
                partieActuelle.partieTerminee = true;
                StateHasChanged();
            } 
        }

        await SauvegarderPartie();
        return false;
        
    }

    private async Task Fouiller()
    {
        message = "Vous fouillez la piece, ";
        double pointsObtenu = await HttpClient!.GetFromJsonAsync<double>($"api/ScorePartieControlleur/fouillerPiece/{idPartieEnCours}");
        if (pointsObtenu > 0)
        {
            message +="et êtes tombé sur un trésor qui vous rapporte "+pointsObtenu.ToString()+"points";
        }
        else
        {
            message +="et êtes tombé sur un piège qui vous fait perdre "+(pointsObtenu*(-1)).ToString()+"points";
        }
        partieActuelle!.score += pointsObtenu;
        partieActuelle!.aFouille = true;
        await SauvegarderPartie();
    }

    private void Analyser(string description)
    {
        message = "après moulte analyses voici ce que vous avez pu apprendre : " + description;
        StateHasChanged();
    }

    private async Task Fuir()
    {
        if (partieActuelle.progression > 4)
        {
            partieActuelle.partieTerminee = true;
            message = "Vous avez fini la partie !";
        }
        else
        {
            message = "Vous changez de salle";
            await Task.Delay(2000);
            partieActuelle.progression += 1;
            partieActuelle.pointsDeVie += 1;
            partieActuelle.aFouille = false;
            partieActuelle.estVaincu=false;
            var progressionActuel = partieActuelle!.progression;
            salleEnCours = partieActuelle.donjonGenere.sallesList[progressionActuel];
            message = "Un monstre vous attaque ! Que faites vous ?";
        }

        StateHasChanged();
        await SauvegarderPartie();
    }

    private async Task SauvegarderPartie()
    {
        var responseStatut =
            await HttpClient!.PatchAsJsonAsync($"api/ScorePartieControlleur/sauvegarderPartie", partieActuelle!);
        if (responseStatut.IsSuccessStatusCode)
        {
            Console.WriteLine("Sauvegarde réussi");
        }
        else
        {
            // La sauvegarde a échoué (ex: 400 Bad Request, 500 Internal Server Error)
            Console.WriteLine($"Erreur de sauvegarde : {responseStatut.StatusCode}. Détails : {await responseStatut.Content.ReadAsStringAsync()}");
            StateHasChanged();
            // Optionnel : enregistrer l'erreur dans la console pour le débogage
        }
    }

    private async Task ChargerPartie()
        {
            IsLoading = true;
            partieActuelle = null;
            if (HttpClient != null)
                partieActuelle =
                    await HttpClient.GetFromJsonAsync<SharedModels.ScorePartie>(
                        $"api/ScorePartieControlleur/trouverScorePartie/{idPartieEnCours}");
            else
            {
                throw new HttpRequestException(
                    "Erreur lors de la récupération de la partie en cours", 
                    null, 
                    HttpStatusCode.BadRequest
                );
            }
            var progressionActuel = partieActuelle!.progression;
            salleEnCours = partieActuelle.donjonGenere.sallesList[progressionActuel];
            IsLoading = false;
        }
    }