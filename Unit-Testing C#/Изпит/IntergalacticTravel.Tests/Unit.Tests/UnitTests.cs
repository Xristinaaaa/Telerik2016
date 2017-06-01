using System;
using NUnit.Framework;
using Moq;
using IntergalacticTravel;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.Unit.Tests.Mocks;

namespace IntergalacticTravel.Tests.Unit.Tests
{
    [TestFixture]
    public class UnitTests
    {  
        [Test]
        public void Pay_IfObjectPassedIsNull_ShouldThrowException()
        {
            var unit = new MockedUnit(1234, "Ivan");

            Assert.Throws<NullReferenceException>(()=>unit.Pay(null));
        }

        [Test]
        public void Pay_IfValidCost_ShouldDecreaseTheResources()
        {
            var unit = new MockedUnit(1234, "Ivan");
            var initialResources = unit.Resources;

            var cost = new Resources();
            unit.Pay(cost);
            var resultResources = unit.Resources;

            Assert.IsTrue(initialResources==resultResources);
        }
    }
}
