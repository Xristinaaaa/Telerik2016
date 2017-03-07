using SchoolSystem.Framework.Core.Commands.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommandHandler : BaseCommandHandler
    {
        private const string CommandName = "RemoveTeacher";

        private IEngine engine;
        public RemoveTeacherCommandHandler(IEngine engine)
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
            var teacherId = int.Parse(command.Parameters[0]);

            if (!engine.Teachers.ContainsKey(teacherId))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            engine.Teachers.Remove(teacherId);
            return string.Format(@"Calling method GetCommand of type ICommandFactory... 
                Total execution time for method GetCommand of type ICommandFactory is {0} milliseconds.") +
                 string.Format(@"Calling method {0} of type {1} ...
                Total execution time for method {0} of type {1} is {1} milliseconds", command.Name, engine.TeacherFactory) +
                $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
