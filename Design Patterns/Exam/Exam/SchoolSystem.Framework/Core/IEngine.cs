using SchoolSystem.Framework.Factories.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Core
{
    public interface IEngine
    {
        IDictionary<int, ITeacher> Teachers { get; }
        IDictionary<int, IStudent> Students { get; }

        ICommandFactory CommandFactory { get; }
        IMarkFactory MarkFactory { get; }
        IStudentFactory StudentFactory { get; }
        ITeacherFactory TeacherFactory { get; }

        void Start();
    }
}
