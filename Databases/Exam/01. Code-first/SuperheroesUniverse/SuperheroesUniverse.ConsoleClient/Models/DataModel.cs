using System;
using System.Collections.Generic;

namespace SuperheroesUniverse.ConsoleClient.Models
{
    public class DataModel
    {
        public ICollection<SuperheroModel> Superheroes { get; set; }
    }
}
