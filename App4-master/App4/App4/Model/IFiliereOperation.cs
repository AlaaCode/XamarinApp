using System;
using System.Collections.Generic;
using System.Text;

namespace App4.Model
{
    interface IFiliereOperation
    {
        int CreateFiliere(Filiere filiere);
        List<Filiere> ReadFilieres();
        int UpdateFiliere(Filiere filiere);
        void DeleteFiliere(Filiere filiere);
    }
}
