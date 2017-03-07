using ComputersData.Data;
using System;
using System.IO;

namespace ComputersData.Importer.Importers
{
    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<ComputersEntities, TextWriter> Import { get; }
    }
}
