using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePourSqlLite
{
    class EtudiantOperationImpl : IEtudiantOperation
    {
        SQLite.SQLiteConnection database;
        public object CountStudentPerFiliere(string nom)
        {
            var query = database.Query<Etudiant>("SELECT distinct count(*) FROM Etudiant GROUP BY id_fil having nom_filiere = ?",nom);
            return query;
        }

        public EtudiantOperationImpl()
        {
            throw new NotImplementedException();
        }
        public EtudiantOperationImpl(SQLite.SQLiteConnection database)
        {
            this.database = database;
        }
        public int CreateEtudiant(Etudiant etudiant)
        {
                //database.CreateTable<Etudiant>();
            
            return database.Insert(etudiant);
        }
        public Etudiant ReadEtudiant(int cne)
        {
            //database.CreateTable<Etudiant>();
            return (Etudiant)database.Find<Etudiant>(cne);
        }
        public List<Etudiant> ReadEtudiants()
        {
            return database.Table<Etudiant>().ToList();
        }
        
        public int DeleteEtudiant(Etudiant etudiant)
        {
            return database.Delete(etudiant);
        }

        public int UpdateEtudiant(Etudiant etudiant)
        {
            Etudiant e=(Etudiant)database.Find<Etudiant>(etudiant.Cne);
            int cne = etudiant.Cne;
            e = etudiant;
            e.Cne = cne;
            return database.Update(e);

            /*etudiant.Adresse = e.Adresse;
            etudiant.Date_naissance = e.Date_naissance;
            etudiant.Id_fil = e.Id_fil;
            etudiant.Image = e.Image;
            etudiant.Nom = e.Nom;
            etudiant.Prenom = e.Prenom;
            etudiant.Sexe = e.Sexe;
            etudiant.Telephone = e.Telephone;*/
        }
    }
}
