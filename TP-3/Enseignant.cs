namespace TP3;

using System;
using System.Collections.Generic;

public class Enseignant : Personnel
{
    private string Grade;
    private double PrimeDeplacement;
    private int VolumeHoraire;
    private int VolumeHoraireAssignable;
    private Dictionary<string, List<Etudiant>> Groupes; // Liste des groupes (Correction)

    public Enseignant(int code, string nom, string prenom, string bureau, double solde, string grade, double prime, int volumeHoraire, int volumeHoraireAssignable)
        : base(code, nom, prenom, bureau, solde)
    {
        Grade = grade;
        PrimeDeplacement = prime;
        VolumeHoraire = volumeHoraire;
        VolumeHoraireAssignable = volumeHoraireAssignable;
        Groupes = new Dictionary<string, List<Etudiant>>();
    }

    // ✅ Ajouter un getter pour Groupes
    public Dictionary<string, List<Etudiant>> groupes
    {
        get { return Groupes; }
    }

    public void Ajouter_Groupe(string nomGroupe, List<Etudiant> etudiants)
    {
        if (Groupes.ContainsKey(nomGroupe))
        {
            Console.WriteLine("Ce groupe existe deja.");
        }
        else
        {
            Groupes[nomGroupe] = etudiants;
            Console.WriteLine($"Groupe {nomGroupe} ajoute.");
        }
    }

    public void Afficher_Groupes()
    {
        foreach (var groupe in Groupes)
        {
            Console.WriteLine($"Groupe: {groupe.Key}");
            foreach (var etudiant in groupe.Value)
            {
                Console.WriteLine($" - {etudiant}");
            }
        }
    }

    public override double Calculer_Salaire()
    {
        int prixHeure = Grade switch
        {
            "PA" => 300,
            "PH" => 350,
            "PES" => 400,
            _ => 0
        };

        return Solde + PrimeDeplacement + (VolumeHoraire * prixHeure);
    }

    public override string ToString()
    {
        return base.ToString() + $" - {Grade} - Volume Horaire : {VolumeHoraire}";
    }
}

