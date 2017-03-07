using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SuperheroesUniverseModels.Enums;
using System.Collections.Generic;

namespace SuperheroesUniverseModels
{
    public class Superhero
    {
        private ICollection<Power> powers;
        private ICollection<Fraction> fractions;

        public Superhero()
        {
            this.powers = new HashSet<Power>();
            this.fractions = new HashSet<Fraction>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(3)]
        [MaxLength(20)]
        public string SecretIdentity { get; set; }

        [Required]
        [Range(1,3)]
        public AlignmentType Alignment { get; set; }

        [Required]
        public string Story { get; set; }
        
        public int? CityId { get; set; }
        [Required]
        public virtual City City { get; set; }

        public int? RelationshipId { get; set; }
        public virtual Relationship Relationship { get; set; }

        [Required]
        public virtual ICollection<Power> Powers
        {
            get
            {
                return this.powers;
            }
            set
            {
                this.powers = value;
            }
        }
        
        [Required]
        public virtual ICollection<Fraction> Fractions
        {
            get
            {
                return this.fractions;
            }
            set
            {
                this.fractions = value;
            }
        }
    }
}
