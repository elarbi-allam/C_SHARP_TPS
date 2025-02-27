namespace TP3;

public class Etudiant : Personne
{
    private string Niveau;
    private double MoyenneAnnuelle;

    public Etudiant(int code, string nom, string prenom, string niveau, double moyenne)
        : base(code, nom, prenom)
    {
        Niveau = niveau;
        MoyenneAnnuelle = moyenne;
    }

    public override string ToString()
    {
        return base.ToString() + $" - Niveau: {Niveau} - Moyenne: {MoyenneAnnuelle}";
    }
}
