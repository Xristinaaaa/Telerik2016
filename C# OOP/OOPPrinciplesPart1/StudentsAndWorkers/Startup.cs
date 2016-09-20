using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsAndWorkers.List.People;


namespace StudentsAndWorkers
{
    class Startup
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Ivan", "Petrov", 5));
            students.Add(new Student("Pesho", "Ivanov", 2));
            students.Add(new Student("Gosho", "Draganov", 3));
            students.Add(new Student("Stamat", "Georgiev", 6));
            students.Add(new Student("Petur", "Goshev", 7));
            students.Add(new Student("Veselin", "Kolev", 1));
            students.Add(new Student("Ivan", "Kolev", 2));

            var sortedStudents = students
                .OrderBy(x => x.Grade)
                .Select(x => x)
                .ToList();

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Petyr", "Ivanov", 1200, 13));
            workers.Add(new Worker("Stamat", "Stamatov", 1034, 14));
            workers.Add(new Worker("Vesko", "Vasilev", 1223, 10));
            workers.Add(new Worker("Hristo", "Hristov", 1234, 9));
            workers.Add(new Worker("Kolio", "Asparuhov", 1350, 5));
            workers.Add(new Worker("Haralampi", "Minchev", 1320, 7));
            workers.Add(new Worker("Simeon", "Kenov", 1713, 8));

            var sortedWorkers = workers
                .OrderByDescending(x => x.MoneyPerHour())
                .Select(x => x)
                .ToList();

            var merged = new List<Human>();
            merged.AddRange(sortedStudents);
            merged.AddRange(sortedWorkers);

            var sortedMerged = merged
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            foreach (var x in sortedMerged)
            {
                Console.WriteLine(x);
            }
        }
    }
}
