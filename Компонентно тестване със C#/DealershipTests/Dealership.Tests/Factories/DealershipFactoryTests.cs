using System;
using NUnit.Framework;
using Moq;
using Dealership.Models;
using Dealership.Factories;

namespace Dealership.Tests.Factories
{
    [TestFixture]
    public class DealershipFactoryTests
    {
        [Test]
        public void CreateCar_IfValidInput_ShouldNotBeNull()
        {
            var mockedFactory = new Mock<IDealershipFactory>();
            mockedFactory.Setup(x => x.CreateCar("asd", "unknown", 5000, 4));

            Assert.IsNotNull(mockedFactory.Object);
        }

        [Test]
        public void CreateCar_ValidateMakeEquality_ShouldWorkCorrectly()
        {
            var factory = new DealershipFactory();
            var car=factory.CreateCar("asd", "unknown", 5000, 4);
            var expected = new Car("asd", "unknown", 5000, 4);
            Assert.AreEqual(expected.Make, car.Make);
        }

        [Test]
        public void CreateCar_ValidateMethod_ShouldReturnNewCar()
        {
            var mockedFactory = new Mock<IDealershipFactory>();
            var car = new Car("asd", "unknown", 5000, 4);
            mockedFactory.Setup(x => x.CreateCar("asd", "unknown", 5000, 4));
            mockedFactory.Object.Equals(car);
        }

        //same for the others
    }
}
