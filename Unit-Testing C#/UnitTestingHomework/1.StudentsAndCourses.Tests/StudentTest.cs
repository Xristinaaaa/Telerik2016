using System;
using NUnit.Framework;

namespace _1.StudentsAndCourses.Tests
{
    [TestFixture]
    public class StudentTest
    {
        [Test]
        public void Student_ValidName_CheckIfNotNull()
        {
            string name = "Ivan";
            var student = new Student(name);
            Assert.IsNotNull(student);
        }

        [Test]
        public void Student_TestingConstructor_CheckName()
        {
            string name = "Ivan";
            var student = new Student(name);
            Assert.AreSame(name, student.Name);
        }

        [Test]
        public void Student_ValidNumber_CheckIfInRange()
        {
            string name = "Georgi";
            var student = new Student(name);
            Assert.IsTrue(student.UniqueNumber >= 10000 && student.UniqueNumber <= 99999);
        }
    }
}
