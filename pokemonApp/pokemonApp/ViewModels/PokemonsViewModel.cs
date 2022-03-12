using PokeApiNet;
using pokemonApp.Models;
using pokemonApp.Views;
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
        public List<Models.Pokemon> PokemonList;

        public ObservableCollection<Models.Pokemon> PokeList {
            get { return GetValue<ObservableCollection<Models.Pokemon>>(); }
            set { SetValue(value); }
        }

        private static readonly PokemonsViewModel _instance = new PokemonsViewModel();

        public static PokemonsViewModel Instance { 
            get { return _instance; } 
        }

        public PokemonsViewModel() {
            PokeList = new ObservableCollection<Models.Pokemon>();
            Init();
        }

        public void AddPokemon(Models.Pokemon pokemon)
        {
            PokeList.Add(pokemon);
        }

        public void FillPokemonList(List<Models.Pokemon> list)
        {
            PokeList.Clear();
            foreach (Models.Pokemon pokemon in list)
            {
                PokeList.Add(pokemon);
            }
        }

        public async void FillPokemonList()
        {
            PokeList.Clear();
            Database pokemonDB = await Database.Instance;
            PokemonList = pokemonDB.GetPokemonsAsync().Result;
            foreach (Models.Pokemon pokemon in PokemonList)
            {
                PokeList.Add(pokemon);
            }
        }

        public async void FillPokemonDatabase()
        {
            Database pokemonDB = await Database.Instance;
            PokeApiClient client = new PokeApiClient();

            for (int i = 1; i <= 50; i++)
            {
                PokeApiNet.Pokemon poke = await Task.Run(() => client.GetResourceAsync<PokeApiNet.Pokemon>(i));

                await pokemonDB.AddPokemonAsync(new Models.Pokemon
                {
                    Id = poke.Id,
                    Name = poke.Name,
                    Weight = poke.Weight,
                    Height = poke.Height,
                    Moves = poke.Moves[0].Move.Name,
                    Hp = poke.Stats[0].BaseStat,
                    Attacks = poke.Stats[1].BaseStat,
                    Defense = poke.Stats[2].BaseStat,
                    SpecialAttacks = poke.Stats[3].BaseStat,
                    SpecialDefense = poke.Stats[4].BaseStat,
                    Speed = poke.Stats[5].BaseStat,
                    Picture = poke.Sprites.FrontShiny
                });

                //PokeList.Add(pokemon);
                this.FillPokemonList();
                
            }
        }

        public async void Init()
        {
            Database pokemonDB = await Database.Instance;
            if (pokemonDB.IsPokemonDatabaseEmptyAsync().Result == true)
            {
                this.FillPokemonDatabase();
            }
            else
            {
                this.FillPokemonList();
                new PokemonListPage();
            }
        }
    }
}