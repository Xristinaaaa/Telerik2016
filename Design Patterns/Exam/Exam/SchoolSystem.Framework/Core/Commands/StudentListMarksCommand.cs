using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        private IEngine engine;
        public StudentListMarksCommand(IEngine engine)
        {
            this.engine = engine;
        }
        public string Name { get; set; }
        public List<string> Parameters { get; set; }
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = this.engine.Students[studentId];
            return student.ListMarks();
        }
    }
}
