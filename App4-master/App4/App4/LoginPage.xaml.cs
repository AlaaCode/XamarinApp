using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using System.Threading;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserOperation outil;
  

        public LoginPage ()
		{
			InitializeComponent ();
            
		}

        public LoginPage(String path)
        {
            InitializeComponent();
            outil = new UserOperation(this,new SQLite.SQLiteConnection(path));

            //emailField.SetBinding(Entry.TextProperty, email.Value,BindingMode.TwoWay);
           
            
        }



        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //ConsolePourSqlLite.EtudiantOperationImpl etudiantOperation = new ConsolePourSqlLite.EtudiantOperationImpl(App.Connection);

            //DisplayAlert("ss", "e.image=" + etudiantOperation.ReadEtudiants().Last().Image.ToString(), "okkk");
            String email = "", password ="";
             email = emailField.Text;
             password = passwordField.Text;


            
             if(email!=null && password!=null)
             {
                if (Regex.IsMatch(email, "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$"))
                {
                    User s = null;
                    s = outil.FindUserByEmailAndPassword(email, password);
                    if (s == null)
                    {
                        DisplayAlert("ERREUR", "cet utilisateur n'existe pas", "ok");
                    }
                    else
                    {
                        App.Current.MainPage = new NavigationPage(new MainPage());
                    }
                }
                else
                {
                    DisplayAlert("ERREUR", "veuillez saisir un email correcte", "ok");
                }
                 
             }
             else
             {
                 DisplayAlert("ERREUR", "veuillez saisir l'email et le mot de passe", "ok");
             }
             
        }
        


        }
}