using PokeApiNet;
using pokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace pokemonApp.ViewModels
{
    internal class PokemonsViewModel : BaseViewModel
    {
        public ObservableCollection<Models.Pokemon> pokeList {
            get { return GetValue<ObservableCollection<Models.Pokemon>>(); }
            set { SetValue(value); }
        }

        private static PokemonsViewModel _instance = new PokemonsViewModel();
        public static PokemonsViewModel Instance { 
            get { return _instance; } 
        }

        public PokemonsViewModel() {
            pokeList = new ObservableCollection<Models.Pokemon>();
            api();
        }

        async void api()
        {
            PokeApiClient pokeClient = new PokeApiClient();

            for(int i = 1; i<100; i++)
            {
                PokeApiNet.Pokemon poke = await Task.Run(() => pokeClient.GetResourceAsync <PokeApiNet.Pokemon>(i));

                Models.Pokemon pokemon = new Models.Pokemon();
                pokemon.Id = poke.Id;
                pokemon.Name = poke.Name;
                pokemon.Type = poke.Types;
                //pokemon.Picture = poke.Sprites(i);

                pokeList.Add(pokemon);
            }
        }
    }
}