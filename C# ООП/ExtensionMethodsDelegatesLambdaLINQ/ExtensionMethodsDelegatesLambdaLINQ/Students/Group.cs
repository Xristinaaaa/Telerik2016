using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDelegatesLambdaLINQ.Students
{
    class Group
    {
        public int GroupNumber { get; set; }
        public string DepartmentName { get; set; }

        public List<string> Mathematics(List<Student> list)
        {
            var department = list
                .Where(x => x.GroupNumber == "Mathematics")
                .Select(x => x.FullName)
                .ToList();

            return department;
        }

        public void ByGroupNumber(List<Student> list)
        {
            var grouped = list
                .GroupBy(x => x.GroupNumber)
                .ToList();

            foreach (var student in grouped)
            {
                Console.WriteLine(student);
            }
        }
    }
}
