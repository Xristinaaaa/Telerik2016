namespace SchoolClasses.School.Classes
{
    using System;
    using System.Collections.Generic;
    using SchoolClasses.School.People;

    public class Class
    {      
        private string textIdentifier;
        private List<Teacher> teachers;
        private List<Student> students;

        Class(string text, params Teacher[] teachers)
        {
            this.TextIdentifier = text;
            this.teachers=new List<Teacher>();
            this.students = new List<Student>();

            foreach (var teacher in teachers)
            {
                this.teachers.Add(teacher);
            }
            foreach (var student in students)
            {
                this.students.Add(student);
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return new List<Teacher>(this.teachers);
            } 
        }

        public List<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }
        public void RemoveStudent(Student student)
        {
            this.students.Remove(student);
        }

        public string TextIdentifier
        {
            get
            {
                return this.textIdentifier;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Enter text identifier!");
                }
                this.textIdentifier = value;
            }
        }
    }
}
