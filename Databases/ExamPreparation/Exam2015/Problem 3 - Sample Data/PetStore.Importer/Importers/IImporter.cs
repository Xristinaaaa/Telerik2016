using System;
using System.IO;
using PetStore.Data;

namespace PetStore.Importer.Importers
{
    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<PetStoreEntities, TextWriter> Import { get; }
    }
}
