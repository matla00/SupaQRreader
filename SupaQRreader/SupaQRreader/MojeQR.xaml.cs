﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SupaQRreader
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MojeQR : ContentPage
    {
        public MojeQR()
        {
            InitializeComponent();
        }
        async void add_qr(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QRentry());
        }
    }
} 