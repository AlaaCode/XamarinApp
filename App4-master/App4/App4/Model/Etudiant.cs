using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsolePourSqlLite
{
    public class Etudiant
    {
        Int32 cne;
        Int32 id_fil;
        string nom;
        string prenom;
        string adresse;
        string telephone;
        int image;
        string sexe;
        DateTime date_naissance;


        [PrimaryKey, AutoIncrement]
        public int Cne { get => cne; set => cne = value; }

        public int Id_fil { get => id_fil; set => id_fil = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public int Image { get => image; set => image = value; }
        public DateTime Date_naissance { get => date_naissance.Date; set => date_naissance = value; }
        public string Sexe { get => sexe; set => sexe = value; }
    }
}
