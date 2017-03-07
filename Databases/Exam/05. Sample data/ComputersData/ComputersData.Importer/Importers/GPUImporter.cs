using System;
using System.IO;
using ComputersData.Data;

namespace ComputersData.Importer.Importers
{
    public class GPUImporter : IImporter
    {
        private const int GPUToAdd = 15;
        public Action<ComputersEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) =>
                {
                    var id = RandomGenerator.RandomNumber();

                    db.GPUTypes.Add(new GPUType
                    {
                        Id = id,
                        Type = "internal"
                    });

                    db.GPUTypes.Add(new GPUType
                    {
                        Id = ++id,
                        Type = "external"
                    });
                    

                    for (int i = 0; i < GPUToAdd; i++)
                    {
                        if (i == 5)
                        {
                            id += 1;
                        }

                        db.GPUs.Add(new GPU
                        {
                            Id = i + 1,
                            Memory = RandomGenerator.RandomString(2, 15),
                            Vendor = RandomGenerator.RandomString(5, 20),
                            Model = RandomGenerator.RandomString(5, 20),
                            GPUTypeId = id
                        });

                        if (i % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db = new ComputersEntities();
                        }
                    }

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing GPUs";
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }
    }
}
