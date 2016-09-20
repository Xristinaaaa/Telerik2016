namespace StudentsAndWorkers.List.People
{
    using System;
    using StudentsAndWorkers.List.People;

    public class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string first, string last, int salary, int hours)
            :base(first, last)
        {
            this.WeekSalary = salary;
            this.WorkHoursPerDay = hours;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            private set
            {
                if (weekSalary<0)
                {
                    throw new ArgumentException("Salary should be positive.");
                }
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            private set
            {
                if (workHoursPerDay<0)
                {
                    throw new ArgumentException("Number should be positive.");
                }
                this.workHoursPerDay = value;
            }
        }

        //money earned per hour by the worker
        public decimal MoneyPerHour()
        {
            return this.WeekSalary / this.WorkHoursPerDay;
        }
    }
}
