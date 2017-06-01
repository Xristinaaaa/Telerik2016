using System.Collections.Generic;

namespace SchoolSystem.Framework.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Name { get; set; }
        List<string> Parameters { get; set; }
        string Execute(IList<string> parameters);
    }
}
