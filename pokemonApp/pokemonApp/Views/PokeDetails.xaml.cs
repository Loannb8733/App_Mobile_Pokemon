﻿using pokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pokemonApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokeDetails : ContentPage
    {
        public PokeDetails(Pokemon pokemon)
        {
            InitializeComponent();
            BindingContext = pokemon;
        }
    }
}