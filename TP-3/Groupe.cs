namespace TP3;

using System;
using System.Collections.Generic;

public class Groupe
{
    private string Nom;
    private List<Etudiant> Etudiants;

    public Groupe(string nom)
    {
        Nom = nom;
        Etudiants = new List<Etudiant>();
    }

    public void Ajouter_Etudiant(Etudiant etudiant)
    {
        Etudiants.Add(etudiant);
    }

    public void Afficher_Grp()
    {
        Console.WriteLine($"Groupe: {Nom}");
        foreach (var etudiant in Etudiants)
        {
            Console.WriteLine(etudiant);
        }
    }
}
