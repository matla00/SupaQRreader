using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using SupaQRreader.Model;

namespace SupaQRreader
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRreader : ContentPage
    {
        public QRreader()
        {
            InitializeComponent();
        }
        public void scanView_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //await DisplayAlert("Scanned result", "The barcode's text is " + result.Text + ". The barcode's format is " + result.BarcodeFormat, "OK");
                SaveQRresults(result.Text);
                if (Uri.IsWellFormedUriString(result.Text, UriKind.RelativeOrAbsolute))
                {
                    try
                    {
                        await Browser.OpenAsync(result.Text, BrowserLaunchMode.SystemPreferred);
                    }
                    catch (Exception ex)
                    {
                        // An unexpected error occured. No browser may be installed on the device.
                    }
                }
            });

            
        }

        async void SaveQRresults(string QR_text)
        {
            var qr = new QR();
            qr.Name = "";
            qr.QR_text = QR_text;
            qr.Created = false;
            qr.Date_created = DateTime.Now;
            await App.Database.SaveQRAsync(qr);

            int id = await App.Database.GetLastID();
            await Navigation.PushAsync(new QRentry(true, id));
        }
    }
}