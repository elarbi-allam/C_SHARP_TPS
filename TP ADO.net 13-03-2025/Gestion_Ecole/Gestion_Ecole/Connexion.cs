using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Gestion_Ecole
{
    /// <summary>
    /// Classe Connexion qui gère la connexion à la base de données MySQL en utilisant le **modèle Singleton**.
    /// Cette classe permet d'exécuter des requêtes SQL de type SELECT, INSERT, UPDATE et DELETE.
    /// </summary>
    internal class Connexion : IConnexion
    {
        // Instance unique de la connexion (Singleton)
        private static Connexion instance;

        // Objet pour la connexion MySQL
        private MySqlConnection cnx;
        private MySqlCommand cmd;

        /// <summary>
        /// Constructeur privé pour empêcher l'instanciation directe de la classe.
        /// Utilise le **modèle Singleton** pour garantir une seule instance.
        /// </summary>
        private Connexion()
        {
        }

        /// <summary>
        /// Méthode permettant d'obtenir l'unique instance de la classe Connexion.
        /// Si aucune instance n'existe, elle est créée.
        /// </summary>
        /// <returns>Instance unique de la connexion</returns>
        public static Connexion GetInstance()
        {
            if (instance == null)
            {
                instance = new Connexion();
            }
            return instance;
        }

        /// <summary>
        /// Établit une connexion à la base de données.
        /// </summary>
        /// <param name="db_name">Nom de la base de données</param>
        /// <param name="host">Adresse du serveur (par défaut : localhost)</param>
        /// <param name="username">Nom d'utilisateur (par défaut : root)</param>
        /// <param name="password">Mot de passe (par défaut : vide)</param>
        public void Connect(string db_name, string host = "localhost", string username = "root", string password = "")
        {
            try
            {
                // Vérifie si la connexion est fermée avant de l'ouvrir
                if (cnx == null || cnx.State == ConnectionState.Closed)
                {
                    string chaine_cnx = $"User Id={username};Password={password}; Host={host};Database={db_name}";
                    cnx = new MySqlConnection(chaine_cnx);
                    cnx.Open();
                    cmd = new MySqlCommand { Connection = cnx };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la connexion à la base de données : " + ex.Message);
            }
        }

        /// <summary>
        /// Exécute une requête **INSERT, UPDATE ou DELETE** (IUD) sur la base de données.
        /// </summary>
        /// <param name="sql">Requête SQL à exécuter</param>
        /// <param name="parameters">Dictionnaire contenant les paramètres de la requête (optionnel)</param>
        /// <returns>Nombre de lignes affectées, ou -1 en cas d'erreur</returns>
        public int iud(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                cmd.Parameters.Clear(); // Supprime les paramètres précédents pour éviter les doublons
                cmd.CommandText = sql;

                // Ajoute les paramètres à la requête
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        var p = cmd.CreateParameter();
                        p.ParameterName = param.Key;
                        p.Value = param.Value;
                        cmd.Parameters.Add(p);
                    }
                }

                return cmd.ExecuteNonQuery(); // Exécute la requête et retourne le nombre de lignes affectées
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'exécution de la requête IUD : " + ex.Message);
                return -1; // Retourne -1 en cas d'erreur
            }
        }

        /// <summary>
        /// Exécute une requête **SELECT** et retourne un objet **IDataReader** contenant les résultats.
        /// </summary>
        /// <param name="sql">Requête SQL SELECT</param>
        /// <param name="parameters">Dictionnaire contenant les paramètres de la requête (optionnel)</param>
        /// <returns>IDataReader contenant les résultats de la requête, ou null en cas d'erreur</returns>
        public IDataReader select(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = sql;

                // Ajoute les paramètres à la requête
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        var p = cmd.CreateParameter();
                        p.ParameterName = param.Key;
                        p.Value = param.Value;
                        cmd.Parameters.Add(p);
                    }
                }

                return cmd.ExecuteReader(); // Retourne un DataReader contenant les résultats
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'exécution de la requête SELECT : " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Ferme la connexion à la base de données de manière sécurisée.
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                if (cnx != null && cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                    cnx.Dispose();
                    cnx = null;
                    Console.WriteLine("Connexion closed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la fermeture de la connexion : " + ex.Message);
            }
        }
    }
}
