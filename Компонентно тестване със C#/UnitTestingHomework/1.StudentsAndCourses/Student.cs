using System;

namespace _1.StudentsAndCourses
{
    public class Student
    {
        private string name;
        private int uniqueNumber;

        public Student(string name)
        {
            this.name = name;
        }

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
        }

        //name cannot be null
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Wrong input!");
                }
                this.name = value;
            }
        }

        //the unique number is between 10000 and 99999
        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            private set
            {
                if (value<10000 || value>99999)
                {
                    throw new IndexOutOfRangeException("Number should be between 10000 and 99999!");
                }
                this.uniqueNumber = value;
            }
        }

        public void JoinCourse(Course courseToJoin)
        {
            if (!String.IsNullOrEmpty(Name))
            {
                courseToJoin.Join(this);
            }
        }

        public void LeaveCourse(Course courseToLeave)
        {
            if (courseToLeave.NumberOfStudents>1)
            {
                courseToLeave.Leave(this);
            }
        }
    }
}
