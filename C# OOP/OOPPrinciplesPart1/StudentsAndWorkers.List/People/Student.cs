namespace StudentsAndWorkers.List.People
{
    using System;
    using StudentsAndWorkers.List.People;

    public class Student : Human
    {
        private double grade;

        public Student(string first, string last, double grade)
            :base(first, last)
        {
            this.Grade = grade;
        }

        public double Grade
        {
            get
            {
                return this.grade;
            }
            private set
            {
                if (grade<0)
                {
                    throw new ArgumentException("Grade should be positive.");
                }
                this.grade = value;
            }
        }
    }
}
