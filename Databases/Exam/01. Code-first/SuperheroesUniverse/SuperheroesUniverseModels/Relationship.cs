using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;

namespace SuperheroesUniverseModels
{
    public class Relationship
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("FirstHero")]
        public int? FirstHeroId { get; set; }
        public virtual Superhero FirstHero { get; set; }

        [ForeignKey("SecondHero")]
        public int? SecondHeroId { get; set; }
        public virtual Superhero SecondHero { get; set; }
        
        [Range(1,8)]
        public RelationshipType RelationshipType { get; set; }
    }
}
