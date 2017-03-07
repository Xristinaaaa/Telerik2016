using SchoolSystem.Framework.Core.Commands.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommandHandler : BaseCommandHandler
    {
        private const string CommandName = "TeacherAddMark";

        private IEngine engine;
        public TeacherAddMarkCommandHandler(IEngine engine)
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
            var studentId = int.Parse(command.Parameters[1]);
            var mark = float.Parse(command.Parameters[2]);

            var student = engine.Students[studentId];
            var teacher = engine.Teachers[teacherId];

            teacher.AddMark(student, mark);
            return string.Format(@"Calling method GetCommand of type ICommandFactory... 
                Total execution time for method GetCommand of type ICommandFactory is {0} milliseconds.") +
                 string.Format(@"Calling method {0} of type {1} ...
                Total execution time for method {0} of type {1} is {1} milliseconds", command.Name, engine.TeacherFactory) +
                $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }

    }
}
