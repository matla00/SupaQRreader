using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SupaQRreader.Model;

namespace SupaQRreader
{
    public partial class App : Application
    {
        static QRDatabase database;
        public static QRDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new QRDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QR.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new TabbedPage1();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
