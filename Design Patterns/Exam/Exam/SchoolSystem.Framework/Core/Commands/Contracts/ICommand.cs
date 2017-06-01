using System.Collections.Generic;

namespace SchoolSystem.Framework.Core.Commands.Contracts
{
    /// <summary>
    /// Represents a command that can be loaded by the parser.
    /// </summary>
    public interface ICommand
    {
        string Name { get; set; }
        List<string> Parameters { get; set; }
        /// <summary>
        /// Executes the command with the passed parameters.
        /// </summary>
        /// <param name="parameters">Parameters to execute the command with.</param>
        /// <returns>Returns execution result message.</returns>
        string Execute(IList<string> parameters);
    }
}
