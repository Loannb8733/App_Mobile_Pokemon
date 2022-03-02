using PokeApiNet;
using pokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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
            PokeApiClient client = new PokeApiClient();

            for(int i = 1; i<=20; i++)
            {
                PokeApiNet.Pokemon poke = await Task.Run(() => client.GetResourceAsync <PokeApiNet.Pokemon>(i));

                Models.Pokemon pokemon = new Models.Pokemon();
                pokemon.Id = poke.Id;
                pokemon.Name = poke.Name;
                pokemon.Weight = poke.Weight;
                pokemon.Height = poke.Height;
                pokemon.Moves = poke.Moves[0].Move.Name;
                pokemon.Hp = poke.Stats[0].BaseStat;
                pokemon.Attacks = poke.Stats[1].BaseStat;
                pokemon.Defense = poke.Stats[2].BaseStat;
                pokemon.SpecialAttacks = poke.Stats[3].BaseStat;
                pokemon.SpecialDefense = poke.Stats[4].BaseStat;
                pokemon.Speed = poke.Stats[5].BaseStat;
                pokemon.Picture = poke.Sprites.BackShiny;

                pokeList.Add(pokemon);
            }
        }
    }
}