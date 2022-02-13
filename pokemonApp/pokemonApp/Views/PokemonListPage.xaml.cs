using System;
using System.Collections.Generic;
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
    }
}
