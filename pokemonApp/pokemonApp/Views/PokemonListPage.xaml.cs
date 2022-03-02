using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using pokemonApp.Models;
using pokemonApp.ViewModels;
using Xamarin.Forms;

namespace pokemonApp.Views
{
    public partial class PokemonListPage : ContentPage
    {

        public PokemonListPage()
        {
            InitializeComponent();
            BindingContext = PokemonsViewModel.Instance;
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pokemon current = (e.CurrentSelection.FirstOrDefault() as Pokemon);

            if (current == null)
            {
                return;
            }

            (sender as CollectionView).SelectedItem = null;

            await Navigation.PushAsync(new PokeDetails(current));
        }

    }
}
