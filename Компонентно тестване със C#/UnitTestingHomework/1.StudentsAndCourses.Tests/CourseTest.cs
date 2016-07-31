using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace _1.StudentsAndCourses.Tests
{
    [TestFixture]
    public class CourseTest
    {
        [Test]
        public void Course_CheckList_CheckCourse()
        {
            var course = new Course();
            Assert.IsNotNull(course);
        }

        [Test]
        public void Course_StudentsCount_CheckIfCountIsValid()
        {
            var course = new Course();
            course.Join(new Student("Ivan"));
            Assert.IsTrue(course.NumberOfStudents>0 && course.NumberOfStudents <= 30);
        }

        [Test]
        public void Course_JoinStudentsCorrectly_ShouldThrow()
        {
            var course = new Course();
            for (int i = 0; i < 30; i++)
            {
                course.Join(new Student("Gosho"));
            }
            Assert.Throws<IndexOutOfRangeException>(() => course.Join(new Student("Kalin")));
        }

        [Test]
        public void Course_RemoveStudentsCorrectly_ShouldThrow()
        {
            var course = new Course();
            Assert.Throws<Exception>(() => course.Leave(new Student("Ivan")));
        }
    }
}
