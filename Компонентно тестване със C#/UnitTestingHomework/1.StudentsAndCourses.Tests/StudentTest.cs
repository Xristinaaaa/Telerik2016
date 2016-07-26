using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _1.StudentsAndCourses.Tests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void Student_NameIsValid_ShouldThrowIfNull()
        {
            string name = "Ivan";
            var student = new Student(name);
            Assert.IsNotNull(student);
        }

        [TestMethod]
        public void Student_NumberValid_ShouldThrowIfInvalid()
        {
            string name = "Georgi";
            var student = new Student(name);
            Assert.IsTrue(student.UniqueNumber >= 10000 && student.UniqueNumber <= 99999);

        }
    }
}
