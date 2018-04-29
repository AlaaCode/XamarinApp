using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace App4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Courbe : ContentPage
	{
        public List<Entry> entries;
		public Courbe(List<Entry>  entries)
        {
			InitializeComponent ();
            this.entries = entries;
            chart.Chart = new LineChart { Entries = entries };
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