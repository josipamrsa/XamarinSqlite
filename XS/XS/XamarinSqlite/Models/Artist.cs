using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinSqlite.Models
{
    public class Artist
    {
        // Contains info about artist
        [PrimaryKey]
        [AutoIncrement]
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ArtistShareUrl { get; set; }

        public Artist() { }
    }
}
