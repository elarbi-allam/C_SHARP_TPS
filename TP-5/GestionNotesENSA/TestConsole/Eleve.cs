using DB.LIB;
using System;
using System.Collections.Generic;

namespace TestConsole
{
    internal class Eleve : DAO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Niveau { get; set; }
        public string Code_Fil { get; set; }

        public override Dictionary<string, object> ObjectToDictionary()
        {
            return new Dictionary<string, object>
            {
                { "@Id", Id },
                { "@Code", Code },
                { "@Nom", Nom },
                { "@Prenom", Prenom },
                { "@Niveau", Niveau },
                { "@Code_Fil", Code_Fil }
            };
        }

        public override object DictionaryToObject(Dictionary<string, object> dico)
        {
            Eleve e = new Eleve
            {
                Id = Convert.ToInt32(dico["@Id"]),
                Code = dico["@Code"].ToString(),
                Nom = dico["@Nom"].ToString(),
                Prenom = dico["@Prenom"].ToString(),
                Niveau = dico["@Niveau"].ToString(),
                Code_Fil = dico["@Code_Fil"].ToString()
            };
            return e;
        }
    }
}