using System.Data.Entity;
using SocialNetwork.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SocialNetwork.Data
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext()
            :base("SocialNetwork")
        {

        }

        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
