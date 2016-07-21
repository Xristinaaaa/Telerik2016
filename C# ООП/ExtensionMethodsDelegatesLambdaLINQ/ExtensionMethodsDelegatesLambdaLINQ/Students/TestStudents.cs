using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDelegatesLambdaLINQ.Students
{
    public class TestStudents
    {
        public static void Declaration()
        {
            List<Student> listOfStudents = new List<Student>();

            listOfStudents.Add(new Student("Ivan", "Ivanov", 642806, "02241345", "i_ivanov@abv.bg", 1));
            listOfStudents[0].AddMarks(4, 5);
            listOfStudents[0].GroupNumber = "Mathematics";
            listOfStudents.Add(new Student("Georgi", "Georgiev", 642909, "0885345789", "ggeorgiev@abv.bg", 2));
            listOfStudents[1].AddMarks(4.8, 5.5);
            listOfStudents.Add(new Student("Pesho", "Kolev", 643806, "02242121", "pk_kolev@abv.bg", 3));
            listOfStudents[2].AddMarks(3, 4.1);
            listOfStudents[2].GroupNumber = "Mathematics";
            listOfStudents.Add(new Student("Stamat", "Petrov", 642309, "0887123123", "stpetrov@gmail.com", 2));
            listOfStudents[3].AddMarks(6, 6);
            listOfStudents.Add(new Student("Dimitur", "Dimitrov", 644909, "02123095", "dimitrov_d@gmail.com", 2));
            listOfStudents[4].AddMarks(2, 2);

            SelectGroup2(listOfStudents);
            ExtractByEmail(listOfStudents);
            ExtractByPhone(listOfStudents);
            ExtractByMarks(listOfStudents);
            ExtractWithTwoMarks(listOfStudents);
            ExtractAllMarks(listOfStudents);
        }

        public static List<Student> SelectGroup2(List<Student> list)
        {
            var group2 = list
                .Where(x => x.GroupNum == 2)
                .OrderBy(x => x.FirstName)
                .ToList();
            return group2;
        }
        public static List<Student> ExtractByEmail(List<Student> list)
        {
            var group = list
                .Where(x => x.Email.EndsWith("bg"))
                .Select(x => x)
                .ToList();
            return group;
        }
        public static List<Student> ExtractByPhone(List<Student> list)
        {
            var group = list
                .Where(x => x.Tel.StartsWith("02"))
                .Select(x => x)
                .ToList();
            return group;
        }
        public static void ExtractByMarks(List<Student> list)
        {
            var group = list
                .Where(x => x.Marks.Contains(6))
                .ToList();
            var extracted = from Student in @group
                            select new { Student.FullName, Student.Marks };

            foreach (var student in extracted)
            {
                Console.WriteLine(student.ToString());
            }
        }
        public static void ExtractWithTwoMarks(List<Student> list)
        {
            var group = list
                .Where(x => x.Marks[0] == 2 && x.Marks[1] == 2)
                .ToList();
            var extracted = from Student in @group
                            select new { Student.FullName, Student.Marks };

            foreach (var student in extracted)
            {
                Console.WriteLine(student.ToString());
            }
        }
        public static void ExtractAllMarks(List<Student> list)
        {
            var group = list
                .Where(x => x.FacultyNum.ToString().Substring(4, 2) == "06")
                .Select(x => x.Marks)
                .ToList();

            foreach (var marks in group)
            {
                Console.WriteLine(string.Join(", ",marks));
            }
        }
    }
}
