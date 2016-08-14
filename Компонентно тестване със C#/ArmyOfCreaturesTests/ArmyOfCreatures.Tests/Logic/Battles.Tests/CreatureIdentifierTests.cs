using System;
using NUnit.Framework;
using Moq;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Tests.Logic.Battles.Tests
{
    [TestFixture]
    public class CreatureIdentifierTests
    {
        [Test]
        public void CreatureIdentifierFromString_IfInputIsNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CreatureIdentifierFromString_InvalidValueIsPassed_ShouldThrowException()
        {
            var valueToParse = "Angel(asfdas)";
            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse));
        }

        [Test]
        public void CreatureIdentifierFromString_InvalidInputPassed_ShouldThrowException()
        {
            var valueToParse = "Angel";
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse));
        }

        [Test]
        public void CreatureIdentifierFromString_ValidInput_ShouldWorkCorrectly()
        {
            var valueToParse = "Angel(1)";
            Assert.DoesNotThrow(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse));
        }

        [Test]
        public void CreatureIdentifierFromString_ValidInput_ShouldReturnNewIdentifier()
        {
            var valueToParse = "Angel(1)";
            Assert.IsInstanceOf<CreatureIdentifier>(CreatureIdentifier.CreatureIdentifierFromString(valueToParse));
        }

        [Test]
        public void CreatureIdentifierFromString_ValidInput_ShouldReturnExpectedArmyNumber()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            Assert.AreEqual(1, identifier.ArmyNumber);
        }

        [Test]
        public void CreatureIdentifierFromString_ValidInput_ShouldReturnExpectedCreatureType()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            Assert.AreEqual("Angel", identifier.CreatureType);
        }

        [Test]
        public void ToString_ValidInput_ShouldReturnExpectedValue()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            Assert.AreEqual("Angel(1)", identifier.ToString());
        }
    }
}
