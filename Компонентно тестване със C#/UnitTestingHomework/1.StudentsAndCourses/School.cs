using System;
using System.Collections.Generic;

namespace _1.StudentsAndCourses
{
    public class School
    {
        private ICollection<Course> courses;

        public School()
        {
            this.courses = new List<Course>();
        }

        public ICollection<Course> Courses
        {
            get
            {
                return new List<Course>(courses);
            }
        }
    }
}
