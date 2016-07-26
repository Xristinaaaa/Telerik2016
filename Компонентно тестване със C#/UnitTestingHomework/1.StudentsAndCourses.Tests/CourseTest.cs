using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _1.StudentsAndCourses.Tests
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void Course_CheckList_ShouldThrowIfNull()
        {
            var course = new Course();
            Assert.IsNotNull(course);
        }

        [TestMethod]
        public void Course_StudentsCount_ShouldThrowIfOutOfRange()
        {
            var course = new Course();
            Assert.IsTrue(course.NumberOfStudents>0 && course.NumberOfStudents <= 30);
        }

        [TestMethod]
        public void Course_JoinStudentsCorrectly_ShouldThrow()
        {
            var course = new Course();
            var name = "Kalin";
            course.Join(new Student(name));
            Assert.IsTrue(course.NumberOfStudents <= 30);
        }

        [TestMethod]
        public void Course_RemoveStudentsCorrectly_ShouldThrow()
        {
            var course = new Course();
            var name = "Ivan";
            course.Leave(new Student(name));
            Assert.IsTrue(course.NumberOfStudents > 0);
        }
    }
}
