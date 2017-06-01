using System;
using NUnit.Framework;
using Moq;
using IntergalacticTravel;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Extensions;
using IntergalacticTravel.Tests.TeleportStation.Tests.Mocks;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.TeleportStation.Tests
{
    [TestFixture]
    public class TeleportStationTests
    {
        [Test]
        public void Constructor_WhenNewStationIsCreatedWithValidParams_ShouldSetUpAllFields()
        {
            var owner = new Mock<IBusinessOwner>();
            var location = new Mock<ILocation>();
            var galacticMap = new Mock<IEnumerable<IPath>>();

            var teleportStation = new MockedTeleportStation(owner.Object, galacticMap.Object, location.Object);

            Assert.That(teleportStation.IsNotNull);
        }

        [Test]
        public void TeleportUnit_WhenUnitToTeleportIsNull_ShouldThrowException()
        {
            var owner = new Mock<IBusinessOwner>();
            var location = new Mock<ILocation>();
            var galacticMap = new Mock<IEnumerable<IPath>>();

            var teleportStation = new MockedTeleportStation(owner.Object, galacticMap.Object, location.Object);

            Assert.That(()=> teleportStation.TeleportUnit(null, location.Object), Throws.ArgumentNullException.With.Message.Contains("unitToTeleport"));
        }

        [Test]
        public void TeleportUnit_WhenLocationIsNull_ShouldThrowException()
        {
            var owner = new Mock<IBusinessOwner>();
            var location = new Mock<ILocation>();
            var unitToTeleport = new Mock<IUnit>();
            var galacticMap = new Mock<IEnumerable<IPath>>();

            var teleportStation = new MockedTeleportStation(owner.Object, galacticMap.Object, location.Object);

            Assert.That(() => teleportStation.TeleportUnit(unitToTeleport.Object, null), Throws.ArgumentNullException.With.Message.Contains("destination"));
        }

        [Test]
        public void TeleportUnit_WhenUnitIsTryingToUseTeleportStationFromDistantLocation_ShouldThrowException()
        {
            var owner = new Mock<IBusinessOwner>();
            var location = new Mock<ILocation>();
            var unitToTeleport = new Mock<IUnit>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var planet = new Mock<IPlanet>();
            var planet2 = new Mock<IPlanet>();

            location.Setup(x => x.Planet).Returns(planet.Object);
            unitToTeleport.Setup(x => x.CurrentLocation.Planet).Returns(planet2.Object);

            var teleportStation = new MockedTeleportStation(owner.Object, galacticMap.Object, location.Object);
            

            Assert.That(() => teleportStation.TeleportUnit(unitToTeleport.Object, location.Object), Throws.InstanceOf<TeleportOutOfRangeException>().With.Message.Contains("unitToTeleport.CurrentLocation"));
        }

        [Test]
        public void TeleportUnit_WhenUnitsLocationsAreEqual_ShouldThrowException()
        {
            var owner = new Mock<IBusinessOwner>();
            var location = new Mock<ILocation>();
            var unitToTeleport = new Mock<IUnit>();
            var galacticMap = new Mock<IEnumerable<IPath>>();

            var teleportStation = new MockedTeleportStation(owner.Object, galacticMap.Object, location.Object);

            Assert.That(() => teleportStation.TeleportUnit(unitToTeleport.Object, location.Object), Throws.InstanceOf<InvalidTeleportationLocationException>().With.Message.Contains("units will overlap"));
        }
    }
}
