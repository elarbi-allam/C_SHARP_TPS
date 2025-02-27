namespace TP3;

using System;

public class Directeur : Personnel
{
    private static Directeur instance;
    private double PrimeDeplacement;

    private Directeur(int code, string nom, string prenom, string bureau, double solde, double primeDeplacement)
        : base(code, nom, prenom, bureau, solde)
    {
        PrimeDeplacement = primeDeplacement;
    }

    public static Directeur GetInstance(int code, string nom, string prenom, string bureau, double solde, double primeDeplacement)
    {
        if (instance == null)
        {
            instance = new Directeur(code, nom, prenom, bureau, solde, primeDeplacement);
        }
        else
        {
            Console.WriteLine("Erreur : Il ne peut y avoir qu'un seul directeur !");
        }
        return instance;
    }

    public override double Calculer_Salaire()
    {
        return Solde + PrimeDeplacement;
    }
}
