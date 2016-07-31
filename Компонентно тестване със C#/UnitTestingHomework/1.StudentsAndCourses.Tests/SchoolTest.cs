using System;
using NUnit.Framework;

namespace _1.StudentsAndCourses.Tests
{
    [TestFixture]
    public class SchoolTest
    {
        [Test]
        public void School_ValidObject_CheckIfNull()
        {
            var school = new School();
            Assert.IsNotNull(school);
        }

        [Test]
        public void School_ValidateCoursesCount_CheckIfNull()
        {
            var school = new School();

            for (int i = 0; i < 5; i++)
            {
                school.AddCourse(new Course());
            }

            Assert.IsNotNull(school.NumberOfCourses != 0);
        }

        [Test]
        public void School_AddingCourses_CheckIfCorrect()
        {
            var school = new School();
            school.AddCourse(new Course());
            Assert.AreEqual(1, school.NumberOfCourses);
        }

        [Test]
        public void School_RemovingCourses_CheckIfCorrect()
        {
            var school = new School();
            var course = new Course();
            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.AreEqual(0, school.NumberOfCourses);
        }
    }
}
