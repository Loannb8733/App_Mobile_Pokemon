using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pokemonApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string Picture { get; set; }
        public string Moves { get; set; }
        public int Hp { get; set; }
        public int Attacks { get; set; }
        public int Defense { get; set; }
        public int SpecialAttacks { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
    }
}
