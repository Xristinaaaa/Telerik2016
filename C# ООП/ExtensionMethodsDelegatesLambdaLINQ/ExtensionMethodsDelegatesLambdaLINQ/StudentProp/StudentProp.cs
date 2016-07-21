using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDelegatesLambdaLINQ.StudentProp
{
    class StudentProp
    {
        Student[] students =
        {
            new Student { FirstName="Ivan", LastName="Kolev", Age=20 },
            new Student { FirstName="Georgi", LastName="Ivanov", Age=21 },
            new Student { FirstName="Petar", LastName="Petrov", Age=18 },
            new Student { FirstName="Kolio", LastName="Iliev", Age=19 },
        };
        public static Student[] firstBeforeLast(Student[] students)
        {
            var collection = students
                .Where(x => x.FirstName.CompareTo(x.LastName)<0)
                .ToArray();
            return collection;
        }
        public static string[] AgeRange(Student[] students)
        {
            var names = students
                .Where(x => x.Age >= 18 && x.Age <= 24)
                .Select(x => x.FirstName+ " "+x.LastName)
                .ToArray();
            return names;
        }
        public static Student[] Order(Student[] students)
        {
            var sorted = students
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName)
                .ToArray();
            return sorted;
        }
    }
}
