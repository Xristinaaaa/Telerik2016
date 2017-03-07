using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Common;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class Command : ICommand
    {
        private string name;
        private List<string> parameters;
        public Command(string input)
        {
            this.Parameters = parameters;
            this.Name = name;
            this.Execute(this.Parameters);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.ValidateNull(value, "Name cannot be null.");
                this.name = value;
            }
        }

        public List<string> Parameters
        {
            get
            {
                return this.parameters;
            }
            set
            {
                Validator.ValidateNull(value, "Parameters cannot be null.");
                this.parameters = value;
            }
        }

        public string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
