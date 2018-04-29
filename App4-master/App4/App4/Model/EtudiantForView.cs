using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App4.Model
{
    class EtudiantForView : ConsolePourSqlLite.Etudiant
    {
        ImageWithSource imageWithSource;
        public ImageSource MyProperty { get => imageWithSource.ImageSource; }

        internal ImageWithSource ImageWithSource { get => imageWithSource; set => imageWithSource = value; }
    }
}
