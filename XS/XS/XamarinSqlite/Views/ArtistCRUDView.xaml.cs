using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSqlite.Data.Interfaces;
using XamarinSqlite.Data.Stores;
using XamarinSqlite.Models;
using XamarinSqlite.ViewModels;

namespace XamarinSqlite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistCRUDView : ContentPage
    {
        public ArtistAddViewModel ViewModel
        {
            get { return BindingContext as ArtistAddViewModel; }
            set { BindingContext = value; }
        }
        public ArtistCRUDView()
        {
            var artistStore = new ArtistStore(DependencyService.Get<ISQLite>());
            ViewModel = new ArtistAddViewModel(new ArtistViewModel(), artistStore);
            InitializeComponent();

            MessagingCenter.Subscribe<ArtistAddViewModel, ObservableCollection<ArtistViewModel>>(this, "artistsLoaded", (sender, artists) =>
            {
                int c = 0;
                foreach (var art in artists)
                {
                    // there is some room for improvement
                    Label existingArtistName = new Label { Text = art.ArtistName };
                    Label existingArtistUrl = new Label { Text = art.ArtistShareUrl };

                    ArtistGrid.Children.Add(existingArtistName, 0, c);
                    ArtistGrid.Children.Add(existingArtistUrl, 1, c);
                    c++;
                }
            });

            MessagingCenter.Subscribe<ArtistAddViewModel, Artist>(this, "artistAdded", (sender, artist) => {
                ReloadGrid(artist, ArtistGrid);
            });
        }

        private void ReloadGrid(Artist artist, Grid artists)
        {
            var amount = artists.Children.Count / 2; // because of two columns, number needs to be halved for row number

            Label newArtistName = new Label { Text = artist.ArtistName };
            Label newArtistUrl = new Label { Text = artist.ArtistShareUrl };

            artists.Children.Add(newArtistName, 0, amount);
            artists.Children.Add(newArtistUrl, 1, amount);
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
    }
}
