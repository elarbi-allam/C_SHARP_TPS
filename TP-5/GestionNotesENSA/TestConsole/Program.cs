using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Eleve e = new Eleve
            {
                Id = 3, // si auto-incrément, tu n'as pas forcément besoin de le gérer
                Code = "E003",
                Nom = "Dupont",
                Prenom = "Jean",
                Niveau = "1A",
                Code_Fil = "GINF"
            };

            // Requête PostgreSQL d'insertion
            // Adapte la casse : si ta table s'appelle "eleve" en minuscules, tu peux faire : INSERT INTO eleve(...)
            e.SetSqlQuery("INSERT INTO eleve (code, nom, prenom, niveau, code_fil) " +
                          "VALUES (@Code, @Nom, @Prenom, @Niveau, @Code_Fil)");

            int res = e.insert();
            Console.WriteLine("Insertion terminée. Nombre de lignes affectées = " + res);

            Console.ReadLine();
        }
    }
}