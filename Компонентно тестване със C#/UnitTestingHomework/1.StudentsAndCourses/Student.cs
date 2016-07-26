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
            set
            {
                if (String.IsNullOrEmpty(name))
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
            set
            {
                if (this.uniqueNumber<10000 || this.uniqueNumber>99999)
                {
                    throw new IndexOutOfRangeException("Number should be between 10000 and 99999!");
                }
                this.uniqueNumber = value;
            }
        }

    }
}
