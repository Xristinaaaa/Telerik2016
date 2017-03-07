using SchoolSystem.Framework.Factories.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models;

namespace SchoolSystem.Framework.Factories
{
    public class TeacherFactory : ITeacherFactory
    {
        public ITeacher CreateTeacher(string firstName, string lastName, Subject subject)
        {
            return new Teacher(firstName, lastName, subject);
        }
    }
}
