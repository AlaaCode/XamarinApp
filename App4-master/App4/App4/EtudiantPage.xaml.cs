using App4.Model;
using ConsolePourSqlLite;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;

namespace App4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EtudiantPage : ContentPage
	{
        EtudiantOperationImpl etudiantOperation;
        FiliereOperationImpl filiereOperation;
        ImageOperationImpl imageOperationImpl;
        Model.Image img;
        List<string> listFiliere = new List<string>();
        ObservableCollection<Etudiant> listEtudiantModel;
        //juste pour l'affichage
        ObservableCollection<EtudiantForView> listEtudiantModelForView;
        ObservableCollection<EtudiantForView> listEtudiantModelForView2;

        /// <summary>
        /// convertir les Etudiants en EtudiantForView et créer la collection d'Etudiants pour l'affichage
        /// </summary>
        public void Remplir()
        {
            foreach (var etudiant in etudiantOperation.ReadEtudiants())
            {
                EtudiantForView e = new EtudiantForView();
                e.Adresse = etudiant.Adresse;
                e.Cne = etudiant.Cne;
                e.Date_naissance = etudiant.Date_naissance;
                e.Id_fil = etudiant.Id_fil;
                e.Image = etudiant.Image;
                Model.Image image = new Model.Image();
                //DisplayAlert("ss", "e.image="+e.Image.ToString(), "okkk");
                
                image=imageOperationImpl.ReadImage(e.Image);
                ImageWithSource imageWithSource = new ImageWithSource(image);
                imageWithSource.ImageSource = imageOperationImpl.CreateSource(image.Content);
                e.ImageWithSource = imageWithSource;
                //ButtonAjouter.Text = e.ImageWithSource.Content.Length.ToString();
               // Xamarin.Forms.Image imag = new Xamarin.Forms.Image();
                //imag.Source = imageWithSource.ImageSource;
                
                //this.Content = imag;
                //Thread.Sleep(3000);
                e.Nom = etudiant.Nom;
                e.Prenom = etudiant.Prenom;
                e.Sexe = etudiant.Sexe;
                e.Telephone = etudiant.Telephone;

                listEtudiantModelForView.Add(e);
            }
            DisplayAlert("Operation Succeed", "EtudiantForView Ready", "OK");
        }

        public EtudiantPage ()
		{
			InitializeComponent ();
            etudiantOperation = new EtudiantOperationImpl(App.Connection);
            filiereOperation = new FiliereOperationImpl(App.Connection);
            imageOperationImpl = new ImageOperationImpl(App.Connection);
            //image.Source = ImageSource.FromFile(Height > Width ? "icon.png" : "Cute.jpg");
            img = new Model.Image();
            //traitementImage();
            List<Filiere> filieres = filiereOperation.ReadFilieres();
            foreach (var fil in filieres)
            {
                listFiliere.Add(fil.Nom_filiere);
            }
            picker.ItemsSource = listFiliere;
            listEtudiantModel = new ObservableCollection<Etudiant>(etudiantOperation.ReadEtudiants());
            listEtudiantModelForView = new ObservableCollection<EtudiantForView>();
            listEtudiantModelForView2 = new ObservableCollection<EtudiantForView>();
            Remplir();
            DisplayAlert("col", listEtudiantModel.Count.ToString(), "pok");
            

            /*foreach (var img in imageOperationImpl.ReadImages())
            {
                img.ImageSource = imageOperationImpl.CreateSource(img.Content);
            }*/
            /*foreach (var etu in listEtudiantModel)
            {
                Model.Image i=imageOperationImpl.ReadImage(etu.Image);
                
            }*/
            ListEtudiants.ItemsSource = listEtudiantModelForView;
            BindingContext = listEtudiantModelForView;
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

        public void Enregistrer_Clicked(object sender, EventArgs e)
        {
           
        }
        public void FiliereChange(object sender, EventArgs e)
        {
            var filiereSelected = picker.SelectedItem as string;
            //FiliereSelectionnée.Text = filiereSelected;
            int ii = filiereOperation.ReadFilieres().SingleOrDefault(f => f.Nom_filiere == filiereSelected).Id_fil;
            listEtudiantModelForView2 = new ObservableCollection<EtudiantForView>(listEtudiantModelForView.Where(etu => etu.Id_fil ==ii));
            if (listEtudiantModelForView2.Count>0)
            {
                ListEtudiants.ItemsSource = listEtudiantModelForView2;
            }
        }

        public void AjouterEtudiant(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AjoutEtudiant());
            //new AjoutEtudiant();
        }
        public void OnUpdate(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            if (menuitem != null)
            {
                var etudiant = menuitem.BindingContext as Etudiant;
                Navigation.PushAsync(new AjoutEtudiant(etudiant));
            }
        }

           
        public async void OnDelete(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            if (menuitem != null)
            {
                var etudiant = menuitem.BindingContext as Etudiant;
                var answer = await DisplayAlert("Question?", "Voulez-vous vraiment supprimer l'etuidiant " + etudiant.Nom, "Yes", "No");
                if (answer)
                {
                    imageOperationImpl.DeleteImage(imageOperationImpl.ReadImage(etudiantOperation.ReadEtudiant(etudiant.Cne).Image));
                    listEtudiantModelForView.Remove(listEtudiantModelForView.Single(cne=>etudiant.Cne==cne.Cne));
                    listEtudiantModel.Remove(etudiant);
                    Etudiant ee = new Etudiant();
                    ee.Cne = etudiant.Cne;
                    etudiantOperation.DeleteEtudiant(ee);
                    await DisplayAlert("Success", etudiant.Nom + " a été supprimée", "Ok");
                }
                else
                {
                    return;
                }
                
            }
        }
        public void More(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            if (menuitem != null)
            {
                var etudiant = menuitem.BindingContext as Etudiant;
                Navigation.PushAsync(new EtudiantProfil(etudiant));
            }
        }
        

        /*public void traitementImage()
        {
            takePhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }
                try
                {
                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        SaveToAlbum = saveToGallery.IsToggled
                    });
                    if (file == null)
                        return;
                    await DisplayAlert("File Location", (saveToGallery.IsToggled ? file.AlbumPath :
                    file.Path), "OK");

                }
                catch //(Exception ex)
                {

                }
            };
            pickPhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                try
                {
                    Stream stream = null;
                    var file = await CrossMedia.Current.PickPhotoAsync().ConfigureAwait(true);
                    if (file == null)
                        return;
                    stream = file.GetStream();
                    file.Dispose();
                    //image.Source = ImageSource.FromStream(() => stream);
                    System.Threading.Thread.Sleep(2000);
                    stream.Read(img.Content,0,Int32.MaxValue);
                    //img.Id = (int)DateTime.Now.ToBinary();
                }
                catch (Exception ex)
                {
                    // Xamarin.Insights.Report(ex);
                    // await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured
                    await DisplayAlert("Photo Non enregistrée", ":( error."+ex.Message, "OK");
                }
            };
        }*/
    }
}