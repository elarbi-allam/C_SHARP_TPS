namespace TP1;

public class Repertoire
{
    private string nom;
    private int nbr_fichiers;
    private Fichier[] fichiers = new Fichier[30];
    public string Nom { get; set; }
    public string Nbr_fichiers { get; set; }
    public Fichier[] Fichiers { get; set; }
    public Repertoire(){}
    public Repertoire(string nom)
    {
        this.nom = nom;

    }

    public void Afficher() {
        Console.WriteLine($"{nom}: {nbr_fichiers} fichiers:");
        for(int i=0;i<nbr_fichiers;i++)
            Console.WriteLine(fichiers[i]);
    }

    public int Rechercher(string nom) {
        for(int i=0; i<nbr_fichiers; i++)
            if (fichiers[i].Nom == nom)
                return i;
        return -1;
    }

    public int Ajouter(Fichier fichier) {
        if (nbr_fichiers==30)return -1;
        fichiers[nbr_fichiers++] = fichier;
        return 1;
    }

    public void RechercherPdf() {
        foreach(Fichier? fichier in fichiers)
            if(fichier?.Extension == "pdf")
                Console.WriteLine(fichier);
    }

    public void Supprimer(string nom)
    {
        for(int i=0; i<nbr_fichiers;i++)
        {
            if (fichiers[i].Nom == nom)
            {
                for (int j = i; j < nbr_fichiers-1; j++)
                {
                    fichiers[j] = fichiers[j + 1];
                }
                nbr_fichiers--;break;
            }
        }
    }
    
    public void Renommer(string nom, string newNom)
    {
        foreach(Fichier fichier in fichiers)
        {
            if (fichier.Nom == nom)
            {
                fichier.Nom = newNom;
                break;
            }
        }
    }

    public void ModifierTaille(string nom, float taille)
    {
        foreach (Fichier? fichier in fichiers)
        {
            if (fichier?.Nom == nom)
            {
                fichier.Taille = taille;break;
            }
        }
    }

    public float GetTaille()
    {
        float tailleMax = 0;
        for(int i=0; i<nbr_fichiers;i++)
            tailleMax+=fichiers[i].Taille;
        return tailleMax/1000;
    }
}