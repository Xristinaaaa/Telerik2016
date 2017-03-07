using ComputersData.Data;
using ComputersData.Importer.Importers;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ComputersData.Importer
{
    public class DataImporter
    {
        private readonly TextWriter textWriter;
        private DataImporter(TextWriter textwriter)
        {
            this.textWriter = textwriter;
        }
        public static DataImporter Create(TextWriter textwriter)
        {
            return new DataImporter(textwriter);
        }

        public void Import()
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IImporter).IsAssignableFrom(t)
                    && !t.IsInterface && !t.IsAbstract)
                .Select(t => (IImporter)Activator.CreateInstance(t))
                .OrderBy(i => i.Order)
                .ToList()
                .ForEach(i =>
                {
                    var db = new ComputersEntities();
                    this.textWriter.WriteLine(i.Message);
                    i.Import(db, this.textWriter);
                    this.textWriter.WriteLine();
                });
        }
    }
}
