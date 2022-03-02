﻿using Newtonsoft.Json;
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
        public string Picture { get; set; }
    }
}
