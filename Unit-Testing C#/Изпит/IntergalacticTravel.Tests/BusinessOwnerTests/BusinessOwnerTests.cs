using System;
using NUnit.Framework;
using Moq;
using IntergalacticTravel;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.BusinessOwnerTests.Mocks;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.BusinessOwnerTests
{
    [TestFixture]
    public class BusinessOwnerTests
    { 
        [Test]
        public void CollectProfits_ShouldIncreaseTheOwnerResources()
        {
            int identificationNumber = 12345;
            string nickName = "Ivan";
            var teleportStations = new List<ITeleportStation>();
            var businessOwner = new MockedBusinessOwner(identificationNumber, nickName, teleportStations);

            businessOwner.CollectProfits();

            Assert.AreNotSame(0, businessOwner.Resources);        
        }
    }
}
