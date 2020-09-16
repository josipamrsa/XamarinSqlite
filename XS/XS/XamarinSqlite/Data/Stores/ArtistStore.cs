using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinSqlite.Data.Interfaces;
using XamarinSqlite.Models;

namespace XamarinSqlite.Data.Stores
{
    public class ArtistStore : IArtistStore
    {
        private SQLiteAsyncConnection _connection;
        public ArtistStore(ISQLite db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Artist>();
        }

        public async Task<IEnumerable<Artist>> GetArtistsAsync()
        {
            return await _connection.Table<Artist>().ToListAsync();
        }

        public async Task<Artist> GetArtist(int id)
        {
            return await _connection.FindAsync<Artist>(id);
        }

        public async Task AddArtist(Artist artist)
        {
            await _connection.InsertAsync(artist);
        }

        public async Task UpdateArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteArtist(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}
