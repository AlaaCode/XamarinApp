using App4.Model;
using ConsolePourSqlLite;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistiques : ContentPage
    {
        public List<Entry> entries;
        FiliereOperationImpl filiereOperation;
        EtudiantOperationImpl etudiantOperationImpl;
        public Statistiques()
        {
            InitializeComponent();
            filiereOperation = new FiliereOperationImpl(App.Connection);
            etudiantOperationImpl = new EtudiantOperationImpl(App.Connection);
            entries = new List<Entry>();
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.DB_PATH1))
            {
                var etudiants = connection.Table<Etudiant>().OrderBy(o => o.Id_fil).ToList();


                int i = 1;
                foreach (var fil in filiereOperation.ReadFilieres())
                {
                    int c=etudiants.Count(etu => etu.Id_fil == fil.Id_fil);
                    
                    string col = "#" + i.ToString() + "c3e" + i.ToString() + "0";
                    entries.Add(
                            new Entry(c)
                            {
                                Label = fil.Nom_filiere.ToString(),
                                ValueLabel = c.ToString(),
                                Color = SKColor.Parse(col)
                            });
                    i+=2;
                }

                /*int idf = etudiants.First<Etudiant>().Id_fil;
                
                int cpt = 1;
                for (int i = 0; i < etudiants.Count; i++)
                {
                   if (etudiants.ElementAt<Etudiant>(i).Id_fil == idf) cpt++;
                   else
                   {
                        entries.Add(                              
                            new Entry(cpt)
                              {
                                  Label = idf.ToString(),
                                  ValueLabel = cpt.ToString(),
                                  Color = SKColor.Parse("#2c3e50")
                              });
                            idf = etudiants.ElementAt<Etudiant>(i).Id_fil;
                            cpt = 1;
                   }

                }*/

                //string col = "#" + cpt.ToString() + "c3e" + cpt.ToString() + "0";
                if (entries != null) chart.Chart = new BarChart { Entries = entries };
           }
           
        }
        public void BarsItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Statistiques());
        }

        public void DonutsItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Donust(entries));
        }
        public void CourbeItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Courbe(entries));
        }


    }
}