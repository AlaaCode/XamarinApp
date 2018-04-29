using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace App4.Model
{
    public class Filiere:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        Int32 id_fil;
        string nom_filiere;
        string responsbale;
        DateTime date_creation;


        [PrimaryKey, AutoIncrement]
        public int Id_fil {
            get { return id_fil; }
            set
            {
                id_fil = value;
                OnPropertyChanged("Id_fil");
            }
        }

        [Unique]
        public string Nom_filiere {
            get { return nom_filiere; }
            set
            {
                nom_filiere = value;
                OnPropertyChanged("Nom_filiere");
            }
        }
        public string Responsbale {
            get { return responsbale; }
            set
            {
                responsbale = value;
                OnPropertyChanged("Responsable");
            }
        }
        public DateTime Date_creation {
            get { return date_creation; }
            set
            {
                date_creation = value;
                OnPropertyChanged("Date_creation");
            }
        }
    }
}
