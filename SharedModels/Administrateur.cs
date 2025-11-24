namespace SharedModels;

public class Administrateur
{
    public int administrateurid { get; set; }
    public int utilisateurId { get; set; }
    public Utilisateur utilisateur { get; set; } = null!;
}