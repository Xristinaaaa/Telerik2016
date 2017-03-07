using PetStore.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PetStore.Importer.Importers
{
    public class SpeciesImporter : IImporter
    {
        private const int SpeciesToAdd = 100;

        public Action<PetStoreEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) =>
                {
                    var uniqueSpecies = new HashSet<string>();

                    while(uniqueSpecies.Count < SpeciesToAdd)
                    {
                        uniqueSpecies.Add(RandomGenerator.RandomString(5, 50));
                    }

                    var countryIds = db.Countries
                                        .Select(c => c.Id)
                                        .ToList();
                    var uniqueSpeciesList = uniqueSpecies.ToList();
                    var currentIndex = 0;

                    foreach (var countryId in countryIds)
                    {
                        var speciesPerCountry = RandomGenerator.RandomNumber(2, 8);

                        if (currentIndex + 8 >= uniqueSpeciesList.Count)
                        {
                            speciesPerCountry = uniqueSpeciesList.Count - currentIndex;
                        }

                        for (int i = 0; i < speciesPerCountry; i++)
                        {
                            this.AddSpecies(db, uniqueSpeciesList[currentIndex], countryId);

                            currentIndex++;

                            if (currentIndex % 10 == 0)
                            {
                                tr.Write(".");
                            }

                            if (currentIndex % 100 == 0)
                            {
                                db.SaveChanges();
                                db = new PetStoreEntities();
                            }
                        }
                    }
                    if (currentIndex < uniqueSpeciesList.Count)
                    {
                        var leftSpecies = uniqueSpeciesList.Count - currentIndex;
                        for (int i = 0; i < leftSpecies; i++)
                        {
                            this.AddSpecies(db, uniqueSpeciesList[currentIndex], countryIds[RandomGenerator.RandomNumber(0, countryIds.Count - 1)]);
                            currentIndex++;
                        }
                    }

                    db.SaveChanges();
                };
            }
        }
        private void AddSpecies(PetStoreEntities db, string name, int countryId)
        {
            db.Species.Add(new Species
            {
                Name = name,
                OriginCountryId = countryId
            });
        }
        public string Message
        {
            get
            {
                return "Importing species";
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
