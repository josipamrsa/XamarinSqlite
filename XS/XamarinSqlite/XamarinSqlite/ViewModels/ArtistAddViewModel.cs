using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinSqlite.Data.Interfaces;
using XamarinSqlite.Models;

namespace XamarinSqlite.ViewModels
{
    //----VIEWMODEL FOR ADDING AND DISPLAYING SAVED ARTISTS----//
    public class ArtistAddViewModel : BaseViewModel
    {
        /*
         
        Middle-man between View and Model for artists. All newly inserted data goes through the ArtistViewModel
        and the Artist object is bound to input fields in the corresponding View. If an artist is being added,
        its value is easily checked through the VM it passes through. If the value had changed, a new artist
        is added to the SQLite local database. Automatically, the list of saved artists is refreshed with each
        new addition, and is loaded at startup.
         
        */

        private IArtistStore _artistStore;
        public Artist Artist { get; private set; }

        public ObservableCollection<ArtistViewModel> Artists { get; private set; }
            = new ObservableCollection<ArtistViewModel>();
        

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddArtistCommand { get; private set; }

        public ArtistAddViewModel(ArtistViewModel artistVm, IArtistStore artistStore)
        {
            if (artistVm == null) throw new ArgumentException(nameof(artistVm));
            _artistStore = artistStore;

            LoadDataCommand = new Command(async () => await LoadData());
            AddArtistCommand = new Command(async () => await AddArtist());

            Artist = new Artist
            {
                ArtistId = artistVm.Id,
                ArtistName = artistVm.ArtistName,
                ArtistShareUrl = artistVm.ArtistShareUrl
            };

        }

        private async Task AddArtist()
        {
            if (String.IsNullOrWhiteSpace(Artist.ArtistName)) return;
            await _artistStore.AddArtist(Artist);
            MessagingCenter.Send(this, "artistAdded", Artist);
        }

        // TODO - GET BY ID, DELETE, UPDATE METHODS

        private async Task LoadData()
        {
            var artists = await _artistStore.GetArtistsAsync();
            foreach (var artist in artists) { Artists.Add(new ArtistViewModel(artist)); }
            MessagingCenter.Send(this, "artistsLoaded", Artists);
        }
    }
}
