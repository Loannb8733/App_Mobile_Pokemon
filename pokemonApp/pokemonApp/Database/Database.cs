using pokemonApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pokemonApp
{
    public class Database
    {
        static SQLiteAsyncConnection database;

        public static readonly AsyncLazy<Database> Instance = new AsyncLazy<Database>(async () =>
        {
            var instance = new Database();
            CreateTableResult result = await database.CreateTableAsync<Pokemon>();
            return instance;
        });

        public Database()
        {
            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Pokemon>> GetPokemonsAsync()
        {
            return database.Table<Pokemon>().ToListAsync();
        }

        public Task<Pokemon> GetPokemonByNameAsync(string name)
        {
            return database.Table<Pokemon>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public Task<int> AddPokemonAsync(Pokemon pokemon)
        {
            return database.InsertAsync(pokemon);
            /*if (pokemon.Id == 0)
            {
                return database.UpdateAsync(pokemon);
            }
            else
            {
                return database.InsertAsync(pokemon);
            }*/
        }

        public Task<int> DeletePokemonAsync(Pokemon pokemon)
        {
            return database.DeleteAsync(pokemon);
        }

        public Task<bool> IsPokemonDatabaseEmptyAsync()
        {
            return Task.Run(() => 0 == database.Table<Pokemon>().ToListAsync().Result.Count);
        }

        public Task<int> UpdateDatabseAsync(Pokemon pokemon)
        {
            return database.UpdateAsync(pokemon);
        }


    }

}
