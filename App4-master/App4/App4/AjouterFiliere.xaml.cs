using App4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AjouterFiliere : ContentPage
	{
        FiliereOperationImpl filireOpration;
        Filiere f1;
		public AjouterFiliere ()
		{
			InitializeComponent ();
            filireOpration = new FiliereOperationImpl(App.Connection);
            f1 = new Filiere();
        }
        public void Enregistrer_Clicked(object sender, EventArgs e)
        {
            f1.Nom_filiere = nom.Text;
            f1.Responsbale = resp.Text;
            f1.Date_creation = date.Date;
            var nbr=filireOpration.CreateFiliere(f1);
            if (nbr > 0)
            {
                DisplayAlert("Great"+filireOpration.ReadFilieres().Last().Id_fil.ToString(), "filiere correctement ajouté !", "OK");
                nom.Text = "";
                resp.Text = "";
                date.Date = date.Date;
            }
            else
            {
                DisplayAlert("Aïe Aïe Aïe", "filiere non ajouté !", "OK");
            }
        }
        public void EtudiantItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EtudiantPage());
        }
        public void FiliereItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FilierePage());
        }

        public void StatistiqeItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Statistiques());
        }
    }
}