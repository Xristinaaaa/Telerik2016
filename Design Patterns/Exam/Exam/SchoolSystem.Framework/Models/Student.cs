using System.Collections.Generic;
using System.Linq;
using System.Text;

using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models
{
    public class Student : Person, IStudent
    {
        private readonly string studentHasNoMarks = "This student has no marks.";
        private readonly string studentsMarks = "The student has these marks:";
        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public Grade Grade { get; set; }

        public IList<IMark> Marks { get; private set; }

        public string ListMarks()
        {
            if (this.Marks.Count == 0)
            {
                return studentHasNoMarks;
            }

            var builder = new StringBuilder();
            builder.AppendLine(studentsMarks);

            var marksAsString = this.Marks
                .Select(m => $"{m.Subject} => {m.Value}")
                .ToList();

            marksAsString.ForEach(m => builder.AppendLine(m));

            return builder.ToString();
        }
    }
}
