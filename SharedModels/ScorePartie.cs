using System.Text.Json.Serialization;

namespace SharedModels;

public class ScorePartie
{
    //Score partie permet de gérer les parties générées.
    public int ScorePartieId { get; set; }
    //Joueur qui a commencé la partie
    public int joueurId { get; set; }
    public Joueur joueur { get; set; } = null!;
    public int score { get; set; } = 0;
    public int progression { get; set; } = 0;
    public int pointsDeVie { get; set; } = 5;
    public Boolean partieTerminee { get; set; } = false;
    //Une partie va forcément entrainer la génération de donjons.
    public Donjons? donjonGenere { get; set; }
}