using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinSqlite.Models;

namespace XamarinSqlite.Data.Interfaces
{
    public interface IArtistStore
    {
        //----INTERFACE FOR STORING ARTIST INFO IN SQLITE DATABASE----//
        Task<IEnumerable<Artist>> GetArtistsAsync();
        Task<Artist> GetArtist(int id);
        Task AddArtist(Artist artist);
        Task UpdateArtist(Artist artist);
        Task DeleteArtist(Artist artist);
    }
}
