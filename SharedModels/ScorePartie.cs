namespace SharedModels;

public class ScorePartie
{
    public int joueurId { get; set; }
    public Joueur joueur { get; set; } = null!;
    public int score { get; set; }
}