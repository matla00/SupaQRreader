using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SupaQRreader.Model;
using ZXing.Net.Mobile.Forms;

namespace SupaQRreader
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : ContentPage
    {
        public History()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetQRsAsyncHistory();
        }
        async void zobrazeni(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                QR qr = e.SelectedItem as QR;
                await Navigation.PushAsync(new QRentry(true, qr.ID));
            }
        }
    }
}