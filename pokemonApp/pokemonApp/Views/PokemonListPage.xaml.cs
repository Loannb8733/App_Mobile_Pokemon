using System;
using System.Collections.Generic;
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

    }
}
