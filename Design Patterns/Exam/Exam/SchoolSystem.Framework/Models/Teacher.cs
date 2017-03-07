using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Common;

namespace SchoolSystem.Framework.Models
{
    public class Teacher : Person, ITeacher
    {
        private readonly string marksCountExceeded = $"The student's marks count exceed the maximum count of {Constants.MaxStudentMarksCount} marks";

        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float mark)
        {
            Validator.ValidateIntMaxCount(student.Marks.Count, Constants.MaxStudentMarksCount, marksCountExceeded);
            var newMark = new Mark(this.Subject, mark);
            student.Marks.Add(newMark);
        }
    }
}
