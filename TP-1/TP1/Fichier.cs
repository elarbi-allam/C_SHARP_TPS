namespace TP1;

public class Fichier
{
    private string nom;
    private string extension;
    private float taille;
    public string Nom
    {
        get { return nom;} set { nom=value;} }
    public string Extension
    {
        get { return extension;} set{extension=value;} 
    }
    public float Taille { get { return taille;} set{taille=value;}  }
    public override string ToString()
    {
        return $"{nom}.{extension} ({taille} Ko)";
    }
    
    
}