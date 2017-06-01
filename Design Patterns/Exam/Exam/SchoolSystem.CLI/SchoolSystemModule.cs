using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Factories;
using SchoolSystem.Framework.Factories.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using System.IO;
using System.Reflection;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        private const string CommandName = "Command";
        private const string StudentName = "Student";
        private const string TeacherName = "Teacher";
        private const string MarkName = "Mark";
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .Where(type => type != typeof(Engine))
                .BindDefaultInterface();
            });

            Bind<IEngine>().To<Engine>().InSingletonScope();

            Bind<IParser>().To<CommandParserProvider>();
            Bind<IReader>().To<ConsoleReaderProvider>();
            Bind<IWriter>().To<ConsoleWriterProvider>();

            Bind<ICommand>().To<Command>();
            Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
     
            Bind<IStudentFactory>().To<StudentFactory>().InSingletonScope();
            Bind<ITeacherFactory>().To<TeacherFactory>().InSingletonScope();
            Bind<IMarkFactory>().To<MarkFactory>().InSingletonScope();

            Bind<IPerson>().To<Person>();
            Bind<IStudent>().To<Student>().Named(StudentName);
            Bind<ITeacher>().To<Teacher>().Named(TeacherName);
            Bind<IMark>().To<Mark>().Named(MarkName);

            this.Bind<ICommandHandler>().To<CreateStudentCommandHandler>();
            this.Bind<ICommandHandler>().To<CreateTeacherCommandHandler>();
            this.Bind<ICommandHandler>().To<RemoveStudentCommandHandler>();
            this.Bind<ICommandHandler>().To<RemoveTeacherCommandHandler>();
            this.Bind<ICommandHandler>().To<StudentListMarksCommandHandler>();
            this.Bind<ICommandHandler>().To<TeacherAddMarkCommandHandler>();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();

            if (configurationProvider.IsTestEnvironment)
            {
                //interception
            }
        }
    }
}