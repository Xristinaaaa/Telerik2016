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
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("School cannot be null");
                }
            }
        }

        public int NumberOfCourses
        {
            get
            {
                return this.courses.Count;
            }
        }

        public void AddCourse(Course courseToAdd)
        {
            if (courseToAdd.NumberOfStudents>0 && courseToAdd.NumberOfStudents<=30)
            {
                courses.Add(courseToAdd);
            }
        }

        public void RemoveCourse(Course courseToRemove)
        {
            if (NumberOfCourses!=0 && courses.Contains(courseToRemove))
            {
                courses.Remove(courseToRemove);
            }
        }
    }
}
