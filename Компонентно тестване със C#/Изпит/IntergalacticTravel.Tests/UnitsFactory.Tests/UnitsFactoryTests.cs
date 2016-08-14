using System;
using NUnit.Framework;
using IntergalacticTravel;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Constants;
using IntergalacticTravel.Extensions;
using IntergalacticTravel.Exceptions;

namespace IntergalacticTravel.Tests.UnitsFactory.Tests
{
    [TestFixture]
    public class UnitsFactoryTests
    {
        [Test]
        public void GetUnit_WhenValidCommandIsPassed_ShouldReturnNewProcyon()
        {
            var unitsFactory = new IntergalacticTravel.UnitsFactory();
            var command = "create unit Procyon Gosho 1";

            var result = unitsFactory.GetUnit(command);

            Assert.IsInstanceOf<Procyon>(result);
        }

        [Test]
        public void GetUnit_WhenValidCommandIsPassed_ShouldReturnNewLuyten()
        {
            var unitsFactory = new IntergalacticTravel.UnitsFactory();
            var command = "create unit Luyten Pesho 2";

            var result = unitsFactory.GetUnit(command);

            Assert.IsInstanceOf<Luyten>(result);
        }

        [Test]
        public void GetUnit_WhenValidCommandIsPassed_ShouldReturnNewLacaille()
        {
            var unitsFactory = new IntergalacticTravel.UnitsFactory();
            var command = "create unit Lacaille Tosho 3";

            var result = unitsFactory.GetUnit(command);

            Assert.IsInstanceOf<Lacaille>(result);
        }

        [TestCase("")]
        [TestCase("asfasf")]
        [TestCase("invalidunit")]
        public void GetUnit_WhenInValidCommandIsPassed_ShouldThrowException(string command)
        {
            var unitsFactory = new IntergalacticTravel.UnitsFactory();
            Assert.Throws<InvalidUnitCreationCommandException>(()=>unitsFactory.GetUnit(command));
        }
    }
}
