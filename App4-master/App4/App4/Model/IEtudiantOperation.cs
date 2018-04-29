using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePourSqlLite
{
    interface IEtudiantOperation
    {
        int CreateEtudiant(Etudiant etudiant);
        Etudiant ReadEtudiant(int cne);
        List<Etudiant> ReadEtudiants();
        int UpdateEtudiant(Etudiant etudiant);
        int DeleteEtudiant(Etudiant etudiant);
    }
}
