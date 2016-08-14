using System;
using NUnit.Framework;
using Moq;
using Dealership.Engine;
using Dealership.Factories;
using System.Collections.Generic;
using Dealership.Contracts;

namespace Dealership.Tests.Engine
{
    [TestFixture]
    public class DealershipEngineTests
    {
        [Test]
        public void Start_WhenInputStringIsValidCreateCommand_ShouldBeAdded()
        {
            var command = "Ivan";
            
            var mockedFactory = new Mock<IDealershipFactory>();
            var mockedCommand = new Mock<ICommand>();
            
            var mockedUsers = new Mock<ICollection<IUser>>();
            var mockedLoggedUser = new Mock<IUser>();

            mockedCommand.SetupGet(x => x.Name).Returns("RegisterUser");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { command });
            mockedFactory.Setup(x => x.CreateUser(command, command, "Ivanov", "aasf00asf", ""));
            mockedUsers.Setup(x => x.Count).Returns(5);

            var mockedDealership = new Mock<DealershipEngine>(mockedFactory.Object, mockedCommand.Object);
            //mockedDealership.Start();
        }
    }
}
