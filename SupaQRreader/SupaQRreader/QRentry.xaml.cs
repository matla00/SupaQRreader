using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SupaQRreader.Model;

namespace SupaQRreader
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRentry : ContentPage
    {
        public int ID;
        public QRentry(Boolean id_set = false, int id = 0)
        {
            if (id_set)
            {
                ID = id;
            }
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            QR qr = await App.Database.GetQRAsync(ID);

            Name.Text = qr.Name;
            Text.Text = qr.QR_text;
            //Date_created.Text = qr.Date_created.ToString();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            QR qr = await App.Database.GetQRAsync(ID);
            qr.Name = this.FindByName<Editor>("Name").Text;
            qr.QR_text = this.FindByName<Editor>("Text").Text;
            await App.Database.SaveQRAsync(qr);
            await Navigation.PopAsync();
        }
    }
}