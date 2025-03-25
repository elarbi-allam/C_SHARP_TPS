using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace DB.LIB
{
    public class Connexion : IConnexion
    {
        private IDbConnection cnx;
        private IDbCommand cmd;

        public Connexion()
        {
            // Exemple de chaîne de connexion PostgreSQL (à adapter selon ton environnement)
            // Host = serveur ; Port = 5432 par défaut ; Database = ta base ; Username/Password = identifiants
            string connectionString = "Host=localhost;Port=5432;Database=ensat;Username=postgres;Password=P@$$w0rd;";
            
            // On utilise la classe NpgsqlConnection pour PostgreSQL
            cnx = new NpgsqlConnection(connectionString);
        }

        public void Connect()
        {
            if (cnx.State != ConnectionState.Open)
            {
                cnx.Open();
                // Crée la commande associée à la connexion
                cmd = cnx.CreateCommand();
            }
        }

        public int iud(string sql, Dictionary<string, object> parameters = null)
        {
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text; // PostgreSQL n'utilise pas forcément 'StoredProcedure' comme SQL Server
            cmd.Parameters.Clear();
            if (parameters != null)
            {
                foreach (var kvp in parameters)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = kvp.Key;    // ex: "@id"
                    p.Value = kvp.Value;         // ex: 123
                    cmd.Parameters.Add(p);
                }
            }
            // ExecuteNonQuery = INSERT, UPDATE, DELETE, CREATE, DROP, etc.
            return cmd.ExecuteNonQuery();
        }

        public IDataReader select(string sql, Dictionary<string, object> parameters = null)
        {
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            if (parameters != null)
            {
                foreach (var kvp in parameters)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = kvp.Key;
                    p.Value = kvp.Value;
                    cmd.Parameters.Add(p);
                }
            }
            // ExecuteReader pour SELECT
            return cmd.ExecuteReader();
        }

        public void Dispose()
        {
            if (cmd != null)
                cmd.Dispose();
            if (cnx != null && cnx.State == ConnectionState.Open)
                cnx.Close();
        }
    }
}
