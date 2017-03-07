using PetStore.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PetStore.Importer.Importers
{
    public class ProductsImporter : IImporter
    {
        private const int ProductsToAdd = 20000;

        public Action<PetStoreEntities, TextWriter> Import
        {
            get
            {
                return (db, tr) =>
                {
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;

                    var productsIds = db.Products.Select(p => p.Id).ToList();
                    var species = db.Species.ToList();

                    var addedProducts = 0;
                    foreach (var productId in productsIds)
                    {
                        var numberOfProductsPerCategory = RandomGenerator.RandomNumber(200, 600);

                        if (addedProducts + 600 >= ProductsToAdd)
                        {
                            numberOfProductsPerCategory = ProductsToAdd - addedProducts;
                        }

                        for (int i = 0; i < numberOfProductsPerCategory; i++)
                        {
                            this.AddProduct(db, productId, species);

                            addedProducts++;

                            if (addedProducts % 10 == 0)
                            {
                                tr.Write(".");
                            }

                            if (addedProducts % 100 == 0)
                            {
                                db.SaveChanges();
                                db = new PetStoreEntities();

                                db.Configuration.AutoDetectChangesEnabled = false;
                                db.Configuration.ValidateOnSaveEnabled = false;
                                species = db.Species.ToList();
                            }
                        }
                    }

                    if (addedProducts < ProductsToAdd)
                    {
                        var leftProducts = ProductsToAdd - addedProducts;

                        for (int i = 0; i < leftProducts; i++)
                        {
                            this.AddProduct(db, productsIds[RandomGenerator.RandomNumber(0, productsIds.Count - 1)], species);
                            addedProducts++;
                        }
                    }

                    db.SaveChanges();
                    db.Configuration.AutoDetectChangesEnabled = true;
                    db.Configuration.ValidateOnSaveEnabled = true;
                };
            }
        }
        private void AddProduct(PetStoreEntities db, int categoryId, IList<Species> species)
        {
            var product = new Product
            {
                CategoryId = categoryId,
                Name = RandomGenerator.RandomString(5, 25),
                Price = RandomGenerator.RandomNumber(10, 1000)
            };

            var numberOfSpeciesPerProduct = RandomGenerator.RandomNumber(2, 10);
            for (int i = 0; i < numberOfSpeciesPerProduct; i++)
            {
                product.Species.Add(species[RandomGenerator.RandomNumber(0, species.Count - 1)]);
            }

            db.Products.Add(product);
        }
        public string Message
        {
            get
            {
                return "Importing products";
            }
        }

        public int Order
        {
            get
            {
                return 5;
            }
        }
    }
}
