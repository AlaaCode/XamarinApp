using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    public class MyDataObject
    {

        public String name { get; set; }
        public String prenom { get; set; }

        public static MyDataObject[] MyDatas() {
            return new MyDataObject[]{
                new MyDataObject { name = "Douiab", prenom = "Asmaa" },
                new MyDataObject { name = "Bouaabdali", prenom = "Meryam" },
                new MyDataObject { name = "Willy", prenom = "Nzeseu" },
            };
            }
    };
          
        
    
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EtudiantPagePrincipale : ContentPage
	{
		public EtudiantPagePrincipale ()
		{
			InitializeComponent ();
            
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MyDataGrid.Rows = MyDataObject.MyDatas();
        }
    }
}