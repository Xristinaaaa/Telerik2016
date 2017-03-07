using SuperheroesUniverseModels;
using System.Data.Entity;

namespace SuperheroesUniverse.Data
{
    public class SuperheroesUniverseContext : DbContext
    {
        public SuperheroesUniverseContext()
            :base("SuperheroesUniverse")
        {

        }

        public virtual DbSet<Superhero> Superheroes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Fraction> Fractions { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Power> Powers { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        
    }
}
