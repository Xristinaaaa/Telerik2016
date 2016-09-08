using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bunnies.Contracts
{
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;

    public interface IWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }
}
