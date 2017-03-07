using PetStore.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace PetStore.Importer.Importers
{
    public class CountriesImporter : IImporter
    {
        private const int CountriesToAdd = 20;
        public Action<PetStoreEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) => 
                {
                    var uniqueCountries = new HashSet<string>();
                    var addedCountries = 0;

                    while(uniqueCountries.Count<CountriesToAdd)
                    {
                        uniqueCountries.Add(RandomGenerator.RandomString(5, 50));
                    }

                    foreach (var country in uniqueCountries)
                    {
                        db.Countries.Add(new Country
                        {
                            Name = country
                        });

                        if(addedCountries%10==0)
                        {
                            tr.Write(".");
                        }
                        if(addedCountries% 100 == 0)
                        {
                            db.SaveChanges();
                            db = new PetStoreEntities();
                        }

                        addedCountries++;
                    }

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing countries";
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
