using SuperheroesUniverseModels;
using SuperheroesUniverseModels.Enums;
using System.Collections.Generic;

namespace SuperheroesUniverse.ConsoleClient.Models
{
    public class SuperheroModel
    {
        public string Name { get; set; }
        public string SecretIdentity { get; set; }
        public City City { get; set; }

        public AlignmentType Alignment { get; set; }
        public string Story { get; set; }
        public ICollection<Power> Powers { get; set; }
        public ICollection<Fraction> Fractions { get; set; }
    }
}
