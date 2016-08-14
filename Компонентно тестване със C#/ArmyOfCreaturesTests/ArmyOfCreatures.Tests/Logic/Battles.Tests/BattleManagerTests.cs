using System;
using NUnit.Framework;
using ArmyOfCreatures.Tests.Logic.Battles.Tests.Mocks;
using Moq;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Tests.Logic.Battles.Tests
{
    [TestFixture]
    public class BattleManagerTests
    {
        [Test]
        public void CreaturesFactory_CheckConstructor_ShouldWorkCorrectly()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            Assert.IsNotNull(mockedFactory);
        }

        [Test]
        public void AddCreatures_WhenIdentifierIsNull_ShouldThrowException()
        {
            var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var mockedBattleManager = new MockedBattleManager(mockedCreaturesFactory.Object, mockedLogger.Object);

            Assert.Throws<ArgumentNullException>(() => mockedBattleManager.AddCreatures(null, 5));
        }

        //[Test]
        //public void AddCreatures_WhenIdentifierIsValid_ShouldCallCreateCreature()
        //{
        //    var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
        //    var mockedLogger = new Mock<ILogger>();

        //    var mockedBattleManager = new MockedBattleManager(mockedCreaturesFactory.Object, mockedLogger.Object);

        //    var fixture = new Fixture();

        //    fixture.Customizations.Add(
        //            new TypeRelay(
        //                typeof(Creature),
        //                typeof(Angel)));

        //    var creature = fixture.Create<Creature>();

        //    mockedCreaturesFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

        //    var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

        //    mockedBattleManager.AddCreatures(identifier, 1);

        //    mockedCreaturesFactory.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Exactly(1));
        //}

        [Test]
        public void Attack_WhenAttackerIdentifierIsNull_ShouldThrowException()
        {
            var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var mockedBattleManager = new MockedBattleManager(mockedCreaturesFactory.Object, mockedLogger.Object);

            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.Throws<NullReferenceException>(() => mockedBattleManager.Attack(null, defenderIdentifier));           
        }

        [Test]
        public void Attack_WhenDefenderIdentifierIsNull_ShouldThrowException()
        {
            var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var mockedBattleManager = new MockedBattleManager(mockedCreaturesFactory.Object, mockedLogger.Object);

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.Throws<ArgumentException>(() => mockedBattleManager.Attack(attackerIdentifier, null));
        }

        [Test]
        public void Attack_WhenIdentifiersAreValid_ShouldWorkCorrectly()
        {
            var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var mockedBattleManager = new MockedBattleManager(mockedCreaturesFactory.Object, mockedLogger.Object);

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");

            var creature = new Angel();

            mockedCreaturesFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            mockedBattleManager.AddCreatures(attackerIdentifier, 1);
            mockedBattleManager.AddCreatures(defenderIdentifier, 1);

            mockedBattleManager.Attack(attackerIdentifier, defenderIdentifier);

            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(6));
        }

        [Test]
        public void Attack_WhenArmyNumbersAreEqual_ShouldThrowException()
        {
            var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var mockedBattleManager = new MockedBattleManager(mockedCreaturesFactory.Object, mockedLogger.Object);

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            var creature = new Angel();

            mockedCreaturesFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            mockedBattleManager.AddCreatures(attackerIdentifier, 1);
            mockedBattleManager.AddCreatures(defenderIdentifier, 1);

            Assert.Throws<ArgumentException>(() => mockedBattleManager.Attack(attackerIdentifier, defenderIdentifier));
        }
    }
}
