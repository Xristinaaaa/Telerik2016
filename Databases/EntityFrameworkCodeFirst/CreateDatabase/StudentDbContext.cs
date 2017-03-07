using CreateDatabase.Models;
using System.Data.Entity;

namespace CreateDatabase
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext()
            : base("StudentDb")
        {

        }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
