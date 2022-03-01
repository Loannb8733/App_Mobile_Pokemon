using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pokemonApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = /*new NavigationPage(new PokemonListPage());*/ new MainPage();
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
