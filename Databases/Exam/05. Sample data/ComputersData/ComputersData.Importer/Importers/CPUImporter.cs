using System;
using System.IO;
using ComputersData.Data;
using System.Collections.Generic;

namespace ComputersData.Importer.Importers
{
    public class CPUImporter : IImporter
    {
        private const int CPUToAdd = 10;
        public Action<ComputersEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) =>
                {

                    var uniqueCPUs = new HashSet<string>();
                    var addedCPUs = 0;

                    while (uniqueCPUs.Count < CPUToAdd)
                    {
                        uniqueCPUs.Add(RandomGenerator.RandomString(5, 20));
                    }

                    foreach (var cpu in uniqueCPUs)
                    {
                        var id = 1;
                        db.CPUs.Add(new CPU
                        {
                            Id = id,
                            Model = cpu,
                            Vendor = RandomGenerator.RandomString(5, 20),
                            NumberOfCores = RandomGenerator.RandomNumber(0, 20),
                            ClockCycles = RandomGenerator.RandomString(2, 15)
                        });

                        if (addedCPUs % 10 == 0)
                        {
                            tr.Write(".");
                        }
                        if (addedCPUs % 100 == 0)
                        {
                            db.SaveChanges();
                            db = new ComputersEntities();
                        }

                        id++;
                        addedCPUs++;
                    }

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing CPUs";
            }
        }

        public int Order
        {
            get
            {
                return 2;
            }
        }
    }
}
