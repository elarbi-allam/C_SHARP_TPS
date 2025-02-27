namespace TP3;

public abstract class Personnel : Personne
{
    protected string Bureau;
    protected double Solde;

    public Personnel(int code, string nom, string prenom, string bureau, double solde)
        : base(code, nom, prenom)
    {
        Bureau = bureau;
        Solde = solde;
    }

    public abstract double Calculer_Salaire();
}
