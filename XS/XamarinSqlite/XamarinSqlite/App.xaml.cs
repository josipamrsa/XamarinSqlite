using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSqlite.Views;

namespace XamarinSqlite
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ArtistCRUDView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
