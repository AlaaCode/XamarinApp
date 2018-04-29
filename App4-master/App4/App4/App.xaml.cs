using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsolePourSqlLite;
using SQLite;
using Xamarin.Forms;
using App4.Model;

namespace App4
{
	public partial class App : Application
	{
        static string DB_PATH;
        static SQLite.SQLiteConnection connection;
        public static string DB_PATH1 { get => DB_PATH; set => DB_PATH = value; }
        public static SQLiteConnection Connection { get => connection; set => connection = value; }


        public App ()
		{
			InitializeComponent();

			MainPage = new LoginPage();
		}
        public App(string DB_path)
        {
            InitializeComponent();
            DB_PATH = DB_path;

            connection = new SQLite.SQLiteConnection(DB_PATH);
            connection.CreateTable<Etudiant>();
            connection.CreateTable<User>();
            connection.CreateTable<Filiere>();
            connection.CreateTable<Model.Image>();
            UserOperation uo = new UserOperation(new LoginPage(),connection);
            User s = new User();
            s.Email = "ensas@ensas.com";
            s.Password = "ensas";
            s.Nom = "ENSAS";
            uo.AddUser(s);
            MainPage = new LoginPage(DB_PATH);
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
