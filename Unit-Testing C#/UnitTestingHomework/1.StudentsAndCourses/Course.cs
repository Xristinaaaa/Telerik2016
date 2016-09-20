using System;
using System.Collections.Generic;

namespace _1.StudentsAndCourses
{
    public class Course
    {
        private ICollection<Student> students;

        public Course()
        {
            this.students = new List<Student>();
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(students);
            }
            private set
            {
                if (value.Count>=30)
                {
                    throw new IndexOutOfRangeException("Students should be less than 30!");
                }
            }
        }

        public int NumberOfStudents
        {
            get
            {
                return this.students.Count;
            }
        }

        public void Join(Student newStudent)
        {
            if (this.students.Count==30)
            {
                throw new IndexOutOfRangeException("Cannot add more than 30 students.");
            }
            this.students.Add(newStudent);
        }

        public void Leave(Student studentToLeave)
        {
            if (this.students.Count==0)
            {
                throw new Exception("No students added.");
            }
            this.students.Remove(studentToLeave);
        }
    }
}
