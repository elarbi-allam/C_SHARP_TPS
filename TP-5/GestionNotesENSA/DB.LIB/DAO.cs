using System;
using System.Collections.Generic;

namespace DB.LIB
{
    public class DAO : Connexion, IDAO<object>
    {
        protected string sql = "";

        public DAO()
        {
            // Le constructeur appelle Connect()
            Connect();
        }
        
        public void SetSqlQuery(string query)
        {
            this.sql = query; // On accède à sql car Eleve est une classe dérivée de DAO
        }

        public virtual Dictionary<string, object> ObjectToDictionary()
        {
            // À personnaliser dans les classes dérivées
            return new Dictionary<string, object>();
        }

        public virtual object DictionaryToObject(Dictionary<string, object> dico)
        {
            // À personnaliser dans les classes dérivées
            return null;
        }

        // CRUD
        public virtual int insert()
        {
            // "INSERT INTO Table (col1, col2, ...) VALUES (@param1, @param2, ...)"
            return iud(sql, ObjectToDictionary());
        }

        public virtual int update()
        {
            // "UPDATE Table SET col1=@param1, col2=@param2 WHERE id=@id"
            return iud(sql, ObjectToDictionary());
        }

        public virtual int delete()
        {
            // "DELETE FROM Table WHERE id=@id"
            return iud(sql, ObjectToDictionary());
        }

        public virtual object findById()
        {
            // "SELECT * FROM Table WHERE id=@id"
            return null;
        }

        public virtual List<object> findAll()
        {
            // "SELECT * FROM Table"
            return new List<object>();
        }

        public virtual List<object> find()
        {
            // Requête paramétrée selon des critères
            return new List<object>();
        }
    }
}