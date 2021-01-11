using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SupaQRreader.Model;
using SQLite;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace SupaQRreader.Model
{
    public class QRDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public QRDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<QR>().Wait();
        }

        public Task<List<QR>> GetQRsAsync()
        {
            return _database.Table<QR>().ToListAsync();
        }
        public Task<List<QR>> GetQRsAsyncHistory()
        {
            return _database.Table<QR>().Where(i => i.Created == false).ToListAsync();
        }
        public Task<List<QR>> GetQRsAsyncMojeQR()
        {
            return _database.Table<QR>().Where(i => i.Created == true).ToListAsync();
        }

        public Task<QR> GetQRAsync(int id)
        {
            return _database.Table<QR>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<List<QR>> GeQRAsyncList(int id)
        {
            return _database.Table<QR>()
                            .Where(i => i.ID == id)
                            .ToListAsync();
        }

        public Task<int> SaveQRAsync(QR qr)
        {
            if (qr.ID != 0)
            {
                return _database.UpdateAsync(qr);
            }
            else
            {
                return _database.InsertAsync(qr);
            }
        }
        public void EditQR(QR qr)
        {
            _database.UpdateAsync(qr);
        }

        public Task<int> DeleteQRAsync(QR qr)
        {
            return _database.DeleteAsync(qr);
        }
    }
}