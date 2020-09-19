using System;
using System.Collections.Generic;
using System.Text;
using XamarinSqlite.Models;

namespace XamarinSqlite.ViewModels
{
    //----ARTIST VIEWMODEL----//
    public class ArtistViewModel : BaseViewModel
    {
        /*
         
        Takes note of every change made in artist information. When values are inserted, 
        updated or deleted, ViewModel is notified of such changes. Contains neccessary
        details for accessing each artist.
         
         */

        public int Id { get; set; }
        public ArtistViewModel() { }
        public ArtistViewModel(Artist artist)
        {
            Id = artist.ArtistId;
            ArtistName = artist.ArtistName;
            ArtistShareUrl = artist.ArtistShareUrl;
        }

        private string _artistName;
        public string ArtistName
        {
            get => _artistName;
            set
            {
                SetValue(ref _artistName, value);
                OnPropertyChanged(nameof(ArtistName));
            }
        }

        private string _artistShareUrl;
        public string ArtistShareUrl
        {
            get => _artistShareUrl;
            set
            {
                SetValue(ref _artistShareUrl, value);
                OnPropertyChanged(nameof(ArtistShareUrl));
            }
        }
    }
}
