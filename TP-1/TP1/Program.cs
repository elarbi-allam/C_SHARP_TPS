namespace TP1;


class Program
{
    static void Main(string[] args)
    {

        Fichier fichier1 = new Fichier { Nom = "document1", Extension = "pdf", Taille = 120.5f };
        Fichier fichier2 = new Fichier { Nom = "image1", Extension = "jpg", Taille = 250.3f };
        Fichier fichier3 = new Fichier { Nom = "report", Extension = "pdf", Taille = 300.0f };

        Repertoire repertoire = new Repertoire("MyFolder");

        repertoire.Ajouter(fichier1);
        repertoire.Ajouter(fichier2);
        repertoire.Ajouter(fichier3);

        Console.WriteLine("-- Affichage initial --");
        repertoire.Afficher();

        Console.WriteLine("\n-- Recherche 'image1' --");
        int index = repertoire.Rechercher("image1");
        Console.WriteLine(index != -1 ? $"'image1' trouvé à l'index {index}" : "'image1' non trouvé.");

        Console.WriteLine("\n-- Fichiers PDF --");
        repertoire.RechercherPdf();
        Console.WriteLine("test");
        repertoire.Renommer("report", "AnnualReport");
        Console.WriteLine("\n-- Après renommage 'report' vers 'AnnualReport' --");
        repertoire.Afficher();
        
        repertoire.ModifierTaille("AnnualReport", 400.0f);
        Console.WriteLine("\n-- Après modification de la taille 'AnnualReport' --");
        repertoire.Afficher();

        repertoire.Supprimer("image1");
        Console.WriteLine("\n-- Après suppression de 'image1' --");
        repertoire.Afficher();

        float tailleMax = repertoire.GetTaille();
        Console.WriteLine($"\n-- Taille totale: {tailleMax} Mo");
    }
}