using System;
using NUnit.Framework;
using Moq;
using ArmyOfCreatures.Logic.Specialties;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Tests.Logic.Specialties.Tests
{
    [TestFixture]
    public class AddDefenseWhenSkipTests
    {
        [Test]
        public void AddDefenseWhenSkip_DefenseOutOfRange_ShouldThrowException()
        {
        }

        [Test]
        public void ApplyOnSkip_NullInput_ShouldThrowException()
        {
        }
    }
}
