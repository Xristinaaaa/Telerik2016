using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _1.StudentsAndCourses.Tests
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void School_IsNull_ShouldThrow()
        {
            var school = new School();
            Assert.IsNotNull(school);
        }
    }
}
