using System;
using System.Collections.Generic;
using IntergalacticTravel;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests.BusinessOwnerTests.Mocks
{
    internal class MockedBusinessOwner : BusinessOwner
    {
        public MockedBusinessOwner(int identificationNumber, string nickName, IEnumerable<ITeleportStation> teleportStations) 
            : base(identificationNumber, nickName, teleportStations)
        {
        }
    }
}
