using System;
using EFNorthwind.Data;

namespace NorthwindTwin
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new NORTHWNDEntities();
            db.Database.CreateIfNotExists();
            db.SaveChanges();
        }
    }
}
