using CreateDatabase;
using CreateDatabase.Migrations;
using CreateDatabase.Models;
using System;
using System.Data.Entity;

namespace UseDatabase
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentDbContext, Configuration>());

            using (var db = new StudentDbContext())
            {
                db.Students.Add(new Student { Name = "Ivan Ivanov", Age = 15, Number = 23 });
                db.Students.Add(new Student { Name = "Peter Georgiev", Age = 15, Number = 21 });
                db.Students.Add(new Student { Name = "Stoicho Stoichev", Age = 14, Number = 22 });
                db.Courses.Add(new Course { Name = "Maths", Description = " " });
                db.Homeworks.Add(new Homework { Content = "Maths Homework", TimeSent = DateTime.Now });
                db.SaveChanges();
            }
        }
    }
}
