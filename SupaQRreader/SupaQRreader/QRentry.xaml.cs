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
    public partial class QRentry : ContentPage
    {

        public int ID;
        public Boolean ID_set = false;
        public QRentry(Boolean id_set = false, int id = 0)
        {
            if (id_set)
            {
                ID = id;
                ID_set = id_set;
            }
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (ID_set) { 
            QR qr = await App.Database.GetQRAsync(ID);

                Name.Text = qr.Name;
                Text.Text = qr.QR_text;

                ZXingBarcodeImageView barcode = BarcodeView;

                barcode.BarcodeValue = qr.QR_text;
            }
            //Date_created.Text = qr.Date_created.ToString();
        }
        void EditorTextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue != "")
            {
                BarcodeView.BarcodeValue = e.NewTextValue;
            }
            Console.WriteLine(e.NewTextValue);
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            QR qr = new QR();
            if (ID_set)
            {
                qr = await App.Database.GetQRAsync(ID);
            }
            
            qr.Name = this.FindByName<Editor>("Name").Text;
            qr.QR_text = this.FindByName<Editor>("Text").Text;
            if(!ID_set)
            {
                qr.Date_created = DateTime.Now;
                qr.Created = true;
            }
            await App.Database.SaveQRAsync(qr);
            await Navigation.PopAsync();
        }
        async void delete_qr(object sender, EventArgs e)
        {
            if (ID_set)
            {
                QR qr = await App.Database.GetQRAsync(ID);
                await App.Database.DeleteQRAsync(qr);
                await Navigation.PopAsync();
            }
        }
    }
}