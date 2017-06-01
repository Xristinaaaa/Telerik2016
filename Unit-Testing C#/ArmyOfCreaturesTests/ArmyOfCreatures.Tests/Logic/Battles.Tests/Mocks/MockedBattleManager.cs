using ArmyOfCreatures.Logic.Battles;
using System;
using ArmyOfCreatures.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ArmyOfCreatures.Tests.Logic.Battles.Tests.Mocks
{
    internal class MockedBattleManager : BattleManager
    {
        public MockedBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
            : base(creaturesFactory, logger)
        {
            this.FirstArmyCreatures = new List<ICreaturesInBattle>();
            this.SecondArmyCreatures = new List<ICreaturesInBattle>();
        }

        public ICollection<ICreaturesInBattle> FirstArmyCreatures { get; set; }
        public ICollection<ICreaturesInBattle> SecondArmyCreatures { get; set; }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            if (creatureIdentifier.ArmyNumber == 1)
            {
                this.FirstArmyCreatures.Add(creaturesInBattle);
            }
            else if (creatureIdentifier.ArmyNumber == 2)
            {
                this.SecondArmyCreatures.Add(creaturesInBattle);
            }
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            if (identifier.ArmyNumber == 1)
            {
                return this.FirstArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }
            else
            {
                return this.SecondArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }
        }
    }
}
