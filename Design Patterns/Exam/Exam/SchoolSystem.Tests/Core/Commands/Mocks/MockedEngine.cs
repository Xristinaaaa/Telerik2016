using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Factories.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Core.Commands.Mocks
{
    public class MockedEngine : Engine
    {
        public MockedEngine(IReader readerProvider, IWriter writerProvider, IParser parserProvider, ICommandFactory commandFactory, IMarkFactory markFactory, IStudentFactory studentFactory, ITeacherFactory teacherFactory) 
            : base(readerProvider, writerProvider, parserProvider, commandFactory, markFactory, studentFactory, teacherFactory)
        {
        }

        IDictionary<int, ITeacher> Teachers
        {
            get
            {
                return base.Teachers;
            }
        }
        IDictionary<int, IStudent> Students
        {
            get
            {
                return base.Students;
            }
        }
        ICommandFactory CommandFactory
        {
            get
            {
                return base.CommandFactory;
            }
        }
        IMarkFactory MarkFactory
        {
            get
            {
                return base.MarkFactory;
            }
        }
        IStudentFactory StudentFactory
        {
            get
            {
                return base.StudentFactory;
            }
        }
        ITeacherFactory TeacherFactory
        {
            get
            {
                return base.TeacherFactory;
            }
        }
    }
}
