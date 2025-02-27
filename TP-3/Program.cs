using System;
using TP3;

class Program
{
    static void Main()
    {
        RessourcesHumaines rh = new RessourcesHumaines();
        

        Enseignant e1 = new Enseignant(101, "Ali", "Karim", "B12", 8000, "PA", 500, 20, 40);
        Enseignant e2 = new Enseignant(102, "Samir", "Ahmed", "C14", 7500, "PH", 600, 15, 30);

        rh.Ajouter_Personnel(e1);
        rh.Ajouter_Personnel(e2);

        Console.WriteLine("Liste des enseignants:");
        rh.Afficher_Enseignants();
    }
}