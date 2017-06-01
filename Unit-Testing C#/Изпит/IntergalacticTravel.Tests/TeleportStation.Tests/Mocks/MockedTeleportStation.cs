using System;
using IntergalacticTravel;
using IntergalacticTravel.Contracts;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.TeleportStation.Tests.Mocks
{
    internal class MockedTeleportStation : IntergalacticTravel.TeleportStation
    {
        public IResources resources;

        public MockedTeleportStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location)
            :base(owner, galacticMap, location)
        {
            resources = new Resources();
        }
    }
}
