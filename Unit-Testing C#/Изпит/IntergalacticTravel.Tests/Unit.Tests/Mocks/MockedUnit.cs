using System;
using IntergalacticTravel;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests.Unit.Tests.Mocks
{
    internal class MockedUnit : IntergalacticTravel.Unit, IUnit
    {
        public MockedUnit(int identificationNumber, string nickName)
            :base(identificationNumber, nickName)
        {
        }
    }
}
