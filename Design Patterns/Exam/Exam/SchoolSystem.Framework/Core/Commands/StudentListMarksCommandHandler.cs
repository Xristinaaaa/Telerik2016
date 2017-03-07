using SchoolSystem.Framework.Core.Commands.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommandHandler : BaseCommandHandler
    {
        private const string CommandName = "StudentListMarks";

        private IEngine engine;
        public StudentListMarksCommandHandler(IEngine engine)
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
            var student = engine.Students[studentId];
            return string.Format(@"Calling method GetCommand of type ICommandFactory... 
                Total execution time for method GetCommand of type ICommandFactory is {0} milliseconds.") +
                 string.Format(@"Calling method {0} of type {1} ...
                Total execution time for method {0} of type {1} is {1} milliseconds", command.Name, engine.StudentFactory) +
                student.ListMarks();
        }
    }
}
