namespace SchoolClasses.School.People
{
    using System;

    public class Student : Person
    {
        private int classNumber;

        public Student(string nameOfPerson, int classNum)
            :base(nameOfPerson)
        {
            this.ClassNumber = classNum;
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            set
            {
                if (classNumber<0)
                {
                    throw new ArgumentException("Class number should be a positive number");
                }
                this.classNumber = value;
            }
        }
    }
}
