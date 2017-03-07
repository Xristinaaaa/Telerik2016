using PetStore.Data;
using System;
using System.IO;

namespace PetStore.Importer.Importers
{
    public class CategoriesImporter : IImporter
    {
        private const int CategoriesToAdd = 50;

        public Action<PetStoreEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) =>
                {
                    for (int i = 0; i < CategoriesToAdd; i++)
                    {
                        db.Categories.Add(new Category
                        {
                            Name = RandomGenerator.RandomString(5, 20)
                        });

                        if (i % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db = new PetStoreEntities();
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
                return "Importing categories";
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
