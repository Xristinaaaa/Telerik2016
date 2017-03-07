using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Factories.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Tests.Core.Commands.Mocks;

namespace SchoolSystem.Tests.Core.Commands
{
    public class CreateStudentCommandTests
    {
        [Test]
        public void CreateStudentCommand_CheckExecute_ShouldReturnRightResult()
        {
            var mockedReader = new Mock<IReader>();
            var mockedWriter = new Mock<IWriter>();
            var mockedParser = new Mock<IParser>();
            var mockedCommandFactory = new Mock<ICommandFactory>();
            var mockedMarkFactory = new Mock<IMarkFactory>();
            var mockedStudentFactory = new Mock<IStudentFactory>();
            var mockedTeacherFactory = new Mock<ITeacherFactory>();

            var engine = new MockedEngine(mockedReader.Object, mockedWriter.Object, mockedParser.Object,mockedCommandFactory.Object, 
                            mockedMarkFactory.Object, mockedStudentFactory.Object, mockedTeacherFactory.Object);

            var method = new CreateStudentCommand(engine);

            var command = mockedCommandFactory.Object.CreateCommand("CreateStudent Pesho Peshev 11");
           
            var parameters = command.Parameters;
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var result = method.Execute(parameters);

            Assert.IsInstanceOf<string>(result);
        }
    }
}
