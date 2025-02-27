namespace TP3;

public class Personne
{
    protected int Code;
    protected string Nom;
    protected string Prenom;

    public Personne(int code, string nom, string prenom)
    {
        Code = code;
        Nom = nom;
        Prenom = prenom;
    }

    public override string ToString()
    {
        return $"{Code} - {Nom} {Prenom}";
    }
}


