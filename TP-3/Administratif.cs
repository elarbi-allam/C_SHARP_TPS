namespace TP3;

public class Administratif : Personnel
{
    public Administratif(int code, string nom, string prenom, string bureau, double solde)
        : base(code, nom, prenom, bureau, solde) { }

    public override double Calculer_Salaire()
    {
        return Solde;
    }
}
