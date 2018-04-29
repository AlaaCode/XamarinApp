using App4.Model;
using ConsolePourSqlLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
           /* using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.DB_PATH1))
            {
                connection.CreateTable<Filiere>();
                var filieres = connection.Table<Filiere>().ToList();
                connection.CreateTable<Etudiant>();
                var etudiants = connection.Table<Etudiant>().ToList();
                etudiantIListView.ItemsSource = etudiants;
               
            }*/
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
