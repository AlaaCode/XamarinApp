using System;
using ConsolePourSqlLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App4.Model;

namespace App4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EtudiantProfil : ContentPage
	{
        Etudiant etudiant;
        EtudiantForView ee;
        EtudiantOperationImpl etudiantOperation;
        ImageOperationImpl imageOperationImpl;
        FiliereOperationImpl filiereOperationImpl;
        public EtudiantProfil(Etudiant e)
		{
			InitializeComponent ();
            etudiantOperation = new EtudiantOperationImpl(App.Connection);
            imageOperationImpl = new ImageOperationImpl(App.Connection);
            filiereOperationImpl = new FiliereOperationImpl(App.Connection);

            etudiant = e;
            ee = new EtudiantForView();
            ee.Adresse = etudiant.Adresse;
            ee.Cne = etudiant.Cne;
            ee.Date_naissance = etudiant.Date_naissance;
            ee.Id_fil = etudiant.Id_fil;
            ee.Image = etudiant.Image;
            Model.Image img = new Model.Image();
            //DisplayAlert("ss", "e.image="+e.Image.ToString(), "okkk");

            img = imageOperationImpl.ReadImage(e.Image);
            ImageWithSource imageWithSource = new ImageWithSource(img);
            imageWithSource.ImageSource = imageOperationImpl.CreateSource(img.Content);
            ee.ImageWithSource = imageWithSource;

            ee.Nom = etudiant.Nom;
            ee.Prenom = etudiant.Prenom;
            ee.Sexe = etudiant.Sexe;
            ee.Telephone = etudiant.Telephone;

            //etudiant = ee;
            nom.Text = etudiant.Nom;
            prenom.Text = etudiant.Prenom;
            adresse.Text = etudiant.Adresse;
            tel.Text = etudiant.Telephone;
            Filiere f = new Filiere();
            f.Id_fil = ee.Id_fil;
            sexe.Text = etudiant.Sexe;
            date.Text = etudiant.Date_naissance.ToLongDateString();
            image.Source = ee.MyProperty;

            try
            {
                filiere.Text = filiereOperationImpl.ReadFilieres().SingleOrDefault(fil => fil.Id_fil == f.Id_fil).Nom_filiere;

            }
            catch (Exception ex) { };
            
        }
	}
}