using pokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace pokemonApp.ViewModels
{
    internal class PokemonsViewModel : BaseViewModel
    {
        public ObservableCollection<Pokemon> ListOfPokemons
        {
            get
            {
                return GetValue<ObservableCollection<Pokemon>>();
            }
            set
            {
                SetValue(value);
            }
        }

        private static PokemonsViewModel _instance = new PokemonsViewModel();

        public static PokemonsViewModel Instance
        {
            get
            {
                return _instance;
            }
        }

        public PokemonsViewModel()
        {

            ListOfPokemons = new ObservableCollection<Pokemon>()
            {
                new Pokemon()
                {
                    Name = "Pikachu",
                    Color = "Yellow"
                }
            };
        }
    }
}
