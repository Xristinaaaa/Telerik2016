using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CreateDatabase.Models
{
    public class Course
    {
        private ICollection<Student> students;
        public Course()
        {
            this.students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<string> Materials { get; set; }
        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }
    }
}
