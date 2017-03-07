using SchoolSystem.Framework.Core.Commands.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommandHandler : BaseCommandHandler
    {
        private const string CommandName = "RemoveStudent";

        private IEngine engine;
        public RemoveStudentCommandHandler(IEngine engine)
        {
            if (this.engine == null)
            {
                throw new ArgumentNullException(nameof(engine));
            }

            this.engine = engine;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var studentId = int.Parse(command.Parameters[0]);
            engine.Students.Remove(studentId);
            return string.Format(@"Calling method GetCommand of type ICommandFactory... 
                Total execution time for method GetCommand of type ICommandFactory is {0} milliseconds.") +
                string.Format(@"Calling method {0} of type {1} ...
                Total execution time for method {0} of type {1} is {1} milliseconds", command.Name, engine.StudentFactory) + 
                $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
