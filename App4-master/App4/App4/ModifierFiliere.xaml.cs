using App4.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModifierFiliere : ContentPage
	{
        FiliereOperationImpl filireOpration;
        Filiere f1;
        public ModifierFiliere ()
		{
            InitializeComponent();
            filireOpration = new FiliereOperationImpl(App.Connection);
        }

        public ModifierFiliere(Filiere f)
        {
            InitializeComponent();
            filireOpration = new FiliereOperationImpl(App.Connection);
            f1 = f;
            id.Text = f.Id_fil.ToString();
            nom.Text = f.Nom_filiere;
            resp.Text = f.Responsbale;
            date.Date=f.Date_creation;


        }

        //Enregistrer_Clicked
        public void Enregistrer_Clicked(object sender, EventArgs e)
        {
            f1.Nom_filiere = nom.Text;
            f1.Responsbale = resp.Text;
            f1.Date_creation = date.Date;
            var nbr = filireOpration.UpdateFiliere(f1);
            if (nbr > 0)
            {
                DisplayAlert("Great", "filiere correctement modifiée !", "OK");

            }
            else
            {
                DisplayAlert("Aïe Aïe Aïe", "filiere non modifiée !", "OK");
            }
            Navigation.PushAsync(new FilierePage());
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