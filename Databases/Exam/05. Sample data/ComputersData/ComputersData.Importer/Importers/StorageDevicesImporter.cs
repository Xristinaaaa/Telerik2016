using System;
using System.IO;
using ComputersData.Data;
using System.Collections.Generic;

namespace ComputersData.Importer.Importers
{
    public class StorageDevicesImporter : IImporter
    {
        private const int DevicesToAdd = 30;
        public Action<ComputersEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) =>
                {

                    var id = RandomGenerator.RandomNumber();

                    db.StorageTypes.Add(new StorageType
                    {
                        Id = id,
                        Name = "SSD"
                    });
                    db.StorageTypes.Add(new StorageType
                    {
                        Id = ++id,
                        Name = "HDD"
                    });
                   

                    for (int i = 0; i < DevicesToAdd; i++)
                    {
                        if (i == 8)
                        {
                            id++;
                        }

                        db.StorageDevices.Add(new StorageDevice
                        {
                            Id = i + 1,
                            Vendor = RandomGenerator.RandomString(2, 20),
                            Model = RandomGenerator.RandomString(5, 25),
                            StorageTypeId = id,
                            Size = RandomGenerator.RandomString(1, 15)
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
                return "Importing Storage devices";
            }
        }

        public int Order
        {
            get
            {
                return 3;
            }
        }
    }
}
