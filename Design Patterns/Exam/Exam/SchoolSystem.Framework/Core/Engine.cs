using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Factories.Contracts;

namespace SchoolSystem.Framework.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "End";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;

        private ICommandFactory commandFactory;
        private IMarkFactory markFactory;
        private IStudentFactory studentFactory;
        private ITeacherFactory teacherFactory;

        private IDictionary<int, ITeacher> teachers;
        private IDictionary<int, IStudent> students;
        public Engine(IReader readerProvider, IWriter writerProvider, IParser parserProvider,
            ICommandFactory commandFactory, IMarkFactory markFactory, IStudentFactory studentFactory, ITeacherFactory teacherFactory)
        {
            if (readerProvider == null)
            {
                throw new ArgumentNullException($"Reader {NullProvidersExceptionMessage}");
            }

            if (writerProvider == null)
            {
                throw new ArgumentNullException($"Writer {NullProvidersExceptionMessage}");
            }

            if (parserProvider == null)
            {
                throw new ArgumentNullException($"Parser {NullProvidersExceptionMessage}");
            }

            this.reader = readerProvider;
            this.writer = writerProvider;
            this.parser = parserProvider;

            this.commandFactory = commandFactory;
            this.markFactory = markFactory;
            this.studentFactory = studentFactory;
            this.teacherFactory = teacherFactory;

            this.teachers = new Dictionary<int, ITeacher>();
            this.students = new Dictionary<int, IStudent>();
        }

        public IDictionary<int, ITeacher> Teachers
        {
            get
            {
                return this.teachers;
            }
        }

        public IDictionary<int, IStudent> Students
        {
            get
            {
                return this.students;
            }
        }

        public ICommandFactory CommandFactory { get { return this.commandFactory; } }
        public IMarkFactory MarkFactory { get { return this.markFactory; } }
        public IStudentFactory StudentFactory { get { return this.studentFactory; } }
        public ITeacherFactory TeacherFactory { get { return this.teacherFactory; } }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.writer.WriteLine(executionResult);
        }
    }
}
