using Plugin.Media;
using ConsolePourSqlLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using App4.Model;

namespace App4
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AjoutEtudiant : ContentPage
	{

        List<string> listFiliere = new List<string>();
        FiliereOperationImpl filiereOperation;
        ImageOperationImpl imageOperationImpl;
        EtudiantOperationImpl etudiantOperationImpl;
        Model.Image img;
        public AjoutEtudiant ()
		{
			InitializeComponent ();
            traitementImage();
            /*listFiliere.Add("All");
            listFiliere.Add("Info");
            listFiliere.Add("GTR");
            listFiliere.Add("Indus");*/
            filiereOperation = new FiliereOperationImpl(App.Connection);
            imageOperationImpl = new ImageOperationImpl(App.Connection);
            etudiantOperationImpl = new EtudiantOperationImpl(App.Connection);
            List<Filiere> filieres = filiereOperation.ReadFilieres();
            //listFiliere.Add(" ");
            foreach (var fil in filieres)
            {
                listFiliere.Add(fil.Nom_filiere);
            }
            picker.ItemsSource = listFiliere;
            img = new Model.Image();
        }

        public AjoutEtudiant(Etudiant e)
        {
            Etudiant etudiant = e;
            InitializeComponent();
            filiereOperation = new FiliereOperationImpl(App.Connection);
            imageOperationImpl = new ImageOperationImpl(App.Connection);
            etudiantOperationImpl = new EtudiantOperationImpl(App.Connection);
            /*listFiliere.Add("All");
            listFiliere.Add("Info");
            listFiliere.Add("GTR");
            listFiliere.Add("Indus");*/
            List<Filiere> filieres = filiereOperation.ReadFilieres();
            //listFiliere.Add(" ");
            foreach (var fil in filieres)
            {
                listFiliere.Add(fil.Nom_filiere);
            }
            picker.ItemsSource = listFiliere;
            traitementImage();
            nom.Text = etudiant.Nom;
            prenom.Text = etudiant.Prenom;
            date.Date = etudiant.Date_naissance;
            cne.Text = Convert.ToString(etudiant.Cne);
            adresse.Text= etudiant.Adresse ;
            tel.Text = etudiant.Telephone;
            sexe.Text = etudiant.Sexe;
            //picker.SelectedItem= filiereOperation.ReadFilieres().SingleOrDefault(fil=>fil.Id_fil== etudiant.Id_fil).Nom_filiere;

            img = imageOperationImpl.ReadImage(etudiantOperationImpl.ReadEtudiant(e.Cne).Image);
            ImageWithSource imageWithSource = new ImageWithSource(img);
            imageWithSource.ImageSource = imageOperationImpl.CreateSource(img.Content);
            image.Source = imageWithSource.ImageSource;

        }
        public async void AjouterEtudiant()
        {
            Etudiant etudiant = new Etudiant();
            //img = new Model.Image();
            etudiant.Nom = nom.Text;
            etudiant.Prenom = prenom.Text;
            etudiant.Cne = Convert.ToInt32(cne.Text);
            etudiant.Date_naissance = date.Date;
            etudiant.Adresse = adresse.Text;
            etudiant.Telephone = tel.Text;
            etudiant.Sexe = sexe.Text;
            etudiant.Id_fil = filiereOperation.ReadFilieres().SingleOrDefault(fil=>fil.Nom_filiere==picker.SelectedItem.ToString()).Id_fil;
            EtudiantOperationImpl etudiantOperationImpl = new EtudiantOperationImpl(App.Connection);
            //int iii=
            
            int idd = -1;
            imageOperationImpl.CreateImage(img);
            idd = imageOperationImpl.ReadImages().Last().Id;
            etudiant.Image = idd;
            //etudiantOperationImpl.ReadEtudiants().Last().Image = idd;

            etudiantOperationImpl.CreateEtudiant(etudiant);
            await DisplayAlert(" Success ", " L'etudiant est ajoutée ", "OK");

            //await DisplayAlert(" Success lastimg.id="+idd.ToString(), " l'etudiant est ajoutée Image.Id= "+ etudiantOperationImpl.ReadEtudiants().Last().Image.ToString(), "OK");
        }
        public void traitementImage()
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
                    //file.Dispose();
                    image.Source = ImageSource.FromStream(() => stream);
                    /*image.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });*/
                    var memoryStream = new MemoryStream();
                        file.GetStream().CopyTo(memoryStream);
                        file.Dispose();
                        img.Content=memoryStream.ToArray();
                    await DisplayAlert("img", img.Content.Length.ToString(), "ok");
                    img.FileName = DateTime.Now.ToFileTimeUtc().ToString()+".jpg";
                }
                catch (Exception ex)
                {
                    // Xamarin.Insights.Report(ex);
                    // await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured
                    await DisplayAlert("Photo Non enregistrée", ":( error."+ex.Message, "OK");
                }
            };
        }
        public class ByteToImageFieldConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                ImageSource retSource = null;
                if (value != null)
                {
                    byte[] imageAsBytes = (byte[])value;
                    retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
                }
                return retSource;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}