using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CreateDatabase.Models
{
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;
        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(4), MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public int Number { get; set; }

        [Required]
        public int Age { get; set; }

        public byte[] Picture { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }
        public ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }
            set
            {
                this.homeworks = value;
            }
        }
    }
}
