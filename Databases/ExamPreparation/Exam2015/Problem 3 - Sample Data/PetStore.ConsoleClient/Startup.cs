namespace PetStore.ConsoleClient
{
    using System;
    using Importer;
    using System.Data.Entity.Validation;
    public class Startup
    {
        public static void Main()
        {
            try
            {
                DataImporter.Create(Console.Out).Import();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
