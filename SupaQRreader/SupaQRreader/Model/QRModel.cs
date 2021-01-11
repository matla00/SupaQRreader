using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using SQLite;

namespace SupaQRreader.Model
{
    public class QR
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string QR_text { get; set; }
        public bool Created { get; set; }
        public DateTime Date_created { get; set; }
    }
}