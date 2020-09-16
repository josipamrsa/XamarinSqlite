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
    public class ArtistAddViewModel : BaseViewModel
    {
        private ArtistViewModel _artistInfo;
        private IArtistStore _artistStore;
        public Artist Artist { get; private set; }

        public ObservableCollection<ArtistViewModel> Artists { get; private set; }
            = new ObservableCollection<ArtistViewModel>();
        public ArtistViewModel ArtistInfo
        {
            get { return _artistInfo; }
            set { SetValue(ref _artistInfo, value); }
        }

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

        private async Task LoadData()
        {
            var artists = await _artistStore.GetArtistsAsync();
            foreach (var artist in artists) { Artists.Add(new ArtistViewModel(artist)); }
            MessagingCenter.Send(this, "artistsLoaded", Artists);
        }
    }
}
