using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Gestion_Ecole
{
    /// <summary>
    /// Classe DAOEleve pour gérer les opérations CRUD (Create, Read, Update, Delete) 
    /// sur la table "eleve" dans la base de données.
    /// Utilise le modèle Singleton pour la connexion à la base de données.
    /// </summary>
    internal class DAOEleve : IDAO<Eleve>
    {
        // Instance Singleton de Connexion pour éviter des connexions multiples
        public Connexion connexion = Gestion_Ecole.Connexion.GetInstance();

        /// <summary>
        /// Constructeur de la classe, initialise la connexion à la base de données.
        /// </summary>
        public DAOEleve()
        {
            connexion.Connect("ensat");
        }

        
        
        /// Insère un nouvel élève dans la base de données.
        /// </summary>
        /// <param name="o">Objet Eleve à insérer</param>
        /// <returns>Nombre de lignes affectées (ou -1 en cas d'erreur)</returns>
        public int insert(Eleve o)
        {
            try
            {
                string sql = "INSERT INTO eleve(nom, prenom, ville, specialite) " +
                             "VALUES(@nom, @prenom, @ville, @specialite)";

                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "@nom", o.Nom },
                    { "@prenom", o.Prenom },
                    { "@ville", o.Ville },
                    { "@specialite", o.Specialite }
                };

                return connexion.iud(sql, param);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur MySQL lors de l'insertion : " + ex.Message);
                return -1; // Retourne -1 en cas d'échec pour éviter une exception bloquante
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur inattendue lors de l'insertion : " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Met à jour les informations d'un élève existant.
        /// </summary>
        /// <param name="o">Objet Eleve contenant les nouvelles valeurs</param>
        /// <returns>Nombre de lignes affectées (ou -1 en cas d'erreur)</returns>
        public int update(Eleve o)
        {
            try
            {
                string sql = "UPDATE eleve SET nom = @nom, prenom = @prenom, ville = @ville, specialite = @specialite WHERE id = @id";

                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "@nom", o.Nom },
                    { "@prenom", o.Prenom },
                    { "@ville", o.Ville },
                    { "@specialite", o.Specialite },
                    { "@id", o.Id }
                };

                return connexion.iud(sql, param);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur MySQL lors de la mise à jour : " + ex.Message);
                return -1; // Retourne -1 pour indiquer une erreur
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur inattendue lors de la mise à jour : " + ex.Message);
                return -1;
            }
        }

        
        /// Supprime un élève de la base de données en fonction de son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'élève</param>
        /// <returns>Nombre de lignes affectées (ou -1 en cas d'erreur)</returns>
        public int delete(int id)
        {
            try
            {
                string sql = "DELETE FROM eleve WHERE id = @id";
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "@id", id }
                };

                int rowsAffected = connexion.iud(sql, param);

                if (rowsAffected == 0)
                {
                    Console.WriteLine("Aucun élève trouvé avec l'ID : " + id);
                }
        
                return rowsAffected;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur MySQL lors de la suppression : " + ex.Message);
                return -1; // Retourne -1 en cas d'échec pour éviter une exception bloquante
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur inattendue lors de la suppression : " + ex.Message);
                return -1;
            }
        }


        /// <summary>
        /// Recherche des élèves en fonction des critères spécifiés dans l'objet Eleve.
        /// </summary>
        /// <param name="o">Objet Eleve contenant les critères de recherche</param>
        /// <returns>Liste des élèves correspondant aux critères</returns>
        public List<Eleve> find(Eleve o)
        {
            List<Eleve> list = new List<Eleve>();
            MySqlDataReader reader = null;
            string sql = "SELECT * FROM eleve WHERE 1 = 1"; // Garantit que la requête fonctionne même si aucun critère n'est ajouté
            Dictionary<string, object> dico = o.ObjToDico();

            // Construction dynamique de la requête avec les champs non vides
            foreach (var p in dico)
            {
                if (!string.IsNullOrEmpty(p.Value.ToString())) 
                {
                    sql += " AND " + p.Key + " = @" + p.Key;
                }
            }

            try
            {
                reader = (MySqlDataReader)connexion.select(sql, dico);
                while (reader.Read())
                {
                    list.Add(new Eleve(
                        reader.GetInt32(0), // ID
                        reader.GetString(1), // Nom
                        reader.GetString(2), // Prénom
                        reader.GetString(3), // Ville
                        reader.GetString(4)  // Spécialité
                    ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la recherche : " + ex.Message);
            }
            finally
            {
                reader?.Close(); // Ferme le lecteur pour éviter les fuites de mémoire
            }
            return list;
        }

        /// <summary>
        /// Récupère tous les élèves de la base de données.
        /// </summary>
        /// <returns>Liste de tous les élèves</returns>
        public List<Eleve> findAll()
        {
            List<Eleve> list = new List<Eleve>();
            MySqlDataReader reader = null;
            string sql = "SELECT * FROM eleve";

            try
            {
                reader = (MySqlDataReader)connexion.select(sql);
                while (reader.Read())
                {
                    list.Add(new Eleve(
                        reader.GetInt32(0), // ID
                        reader.GetString(1), // Nom
                        reader.GetString(2), // Prénom
                        reader.GetString(3), // Ville
                        reader.GetString(4)  // Spécialité
                    ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération des élèves : " + ex.Message);
            }
            finally
            {
                reader?.Close();

            }
            return list;
        }

        /// <summary>
        /// Recherche un élève par son identifiant unique.
        /// </summary>
        /// <param name="id">Identifiant de l'élève</param>
        /// <returns>Objet Eleve correspondant ou null si non trouvé</returns>
        public Eleve findById(int id)
        {
            Eleve eleve = null;
            string sql = "SELECT * FROM eleve WHERE id = @id";
            Dictionary<string, object> param = new Dictionary<string, object> { { "@id", id } };
            MySqlDataReader reader = null;

            try
            {
                reader = (MySqlDataReader)connexion.select(sql, param);
                if (reader.Read())
                {
                    eleve = new Eleve(
                        reader.GetInt32(0), // ID
                        reader.GetString(1), // Nom
                        reader.GetString(2), // Prénom
                        reader.GetString(3), // Ville
                        reader.GetString(4)  // Spécialité
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la recherche par ID : " + ex.Message);
            }
            finally
            {
                reader?.Close();
            }
            return eleve;
        }

         
     
    }
}
