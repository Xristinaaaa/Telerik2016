using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public abstract class CourseModel
    {
        private string courseName;

        public string Name { get; set; }
        public string TeacherName { get; set; }
        public IList<string> Students { get; set; }

        public CourseModel(string name)
        {
            this.Name = name;
        }
        public CourseModel(string courseName, string teacherName)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
        }
        public CourseModel(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }


        public string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public abstract override string ToString();
    }
}
