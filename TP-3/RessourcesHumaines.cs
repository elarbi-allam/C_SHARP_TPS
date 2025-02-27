namespace TP3;

using System;
using System.Collections.Generic;

public class RessourcesHumaines : IRessourcesHumaines
{
    private List<Personnel> ListeGRH;

    public RessourcesHumaines()
    {
        ListeGRH = new List<Personnel>();
    }

    public void Ajouter_Personnel(Personnel p)
    {
        ListeGRH.Add(p);
    }

    public void Afficher_Enseignants()
    {
        foreach (var p in ListeGRH)
        {
            if (p is Enseignant enseignant)
            {
                Console.WriteLine(enseignant);
                enseignant.Afficher_Groupes();
            }
        }
    }

    public int Rechercher_Ens(int code)
    {
        for (int i = 0; i < ListeGRH.Count; i++)
        {
            if (ListeGRH[i] is Enseignant enseignant && enseignant.ToString().Contains(code.ToString()))
            {
                return i;
            }
        }
        return -1;
    }

    public void Ajouter_Etudiant(string codeGroupe, Etudiant etudiant)
    {
        foreach (var p in ListeGRH)
        {
            if (p is Enseignant enseignant && enseignant.groupes.ContainsKey(codeGroupe)) // ✅ Utilisation du getter
            {
                enseignant.groupes[codeGroupe].Add(etudiant);
                Console.WriteLine($"Etudiant {etudiant} ajoute au groupe {codeGroupe}.");
                return;
            }
        }
        Console.WriteLine("Groupe non trouve.");
    }
}

