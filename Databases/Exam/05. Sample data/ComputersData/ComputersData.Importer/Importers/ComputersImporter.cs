using System;
using System.IO;
using ComputersData.Data;

namespace ComputersData.Importer.Importers
{
    public class ComputersImporter : IImporter
    {
        private const int ComputersToAdd = 50;
        public Action<ComputersEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) =>
                {
                    var id = RandomGenerator.RandomNumber();

                    db.ComputerTypes.Add(new ComputerType
                    {
                        Id = id,
                        Name = "ultrabook"
                    });

                    db.ComputerTypes.Add(new ComputerType
                    {
                        Id = ++id,
                        Name = "notebook"
                    });

                    db.ComputerTypes.Add(new ComputerType
                    {
                        Id = 1 + (++id),
                        Name = "desktop"
                    });
                   

                    for (int i = 0; i < ComputersToAdd; i++)
                    {
                        if (i == 16 || i == 32)
                        {
                            id +=1;
                        }

                        db.Computers.Add(new Computer
                        {
                            Id = i + 1,
                            Memory = RandomGenerator.RandomString(1, 15),
                            StorageDeviceId = RandomGenerator.RandomNumber(),
                            GPUId= RandomGenerator.RandomNumber(),
                            CPUId = RandomGenerator.RandomNumber(),
                            Vendor = RandomGenerator.RandomString(5, 20),
                            Model = RandomGenerator.RandomString(5, 20),
                            ComputerTypeId = id
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
                return "Importing computers";
            }
        }

        public int Order
        {
            get
            {
                return 4;
            }
        }
    }
}
