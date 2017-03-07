using SuperheroesUniverseModels.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverseModels
{
    public class Fraction
    {
        private ICollection<Planet> planets;
        private ICollection<Superhero> members;

        public Fraction()
        {
            this.planets = new HashSet<Planet>();
            this.members = new HashSet<Superhero>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Range(1,3)]
        public AlignmentType Alignment { get; set; }

        public virtual ICollection<Planet> Planets
        {
            get
            {
                return this.planets;
            }
            set
            {
                this.planets = value;
            }
        }

        public virtual ICollection<Superhero> Members
        {
            get
            {
                return this.members;
            }
            set
            {
                this.members = value;
            }
        }
    }
}
