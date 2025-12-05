using System.Text.Json.Serialization;

namespace SharedModels;

public class ScorePartie
{
    //Score partie permet de gérer les parties générées.
    public int ScorePartieId { get; set; }
    //Joueur qui a commencé la partie
    public int joueurId { get; set; }
    public Joueur? joueur { get; set; } = null!;
    public double score { get; set; } = 0;
    public int progression { get; set; } = 0;
    public int pointsDeVie { get; set; } = 5;
    public int degatsInfliges {get; set;} = 0;
    public Boolean partieTerminee { get; set; } = false;
    //Une partie va forcément entrainer la génération de donjons.
    public int donjonId { get; set; }
    public Donjons donjonGenere { get; set; } = null!;
    //Nous permet d'enregistrer ce que le joueur a fait dans la partie
    public bool estVaincu=false;
    public bool aFouille =false;
}