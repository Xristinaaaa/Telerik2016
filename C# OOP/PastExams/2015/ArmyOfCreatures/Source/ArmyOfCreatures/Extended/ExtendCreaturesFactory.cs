namespace ArmyOfCreatures.Extended
{
    using Creatures;
    using Logic;
    using Logic.Creatures;
    using System;


    public class ExtendCreaturesFactory : CreaturesFactory
    {
        public override Creature CreateCreature(string name)
        {
            switch (name)
            {
                case "AncientBehemoth":
                    return new AncientBehemoth();
                case "CyclopsKing":
                    return new CyclopsKing();
                case "Goblin":
                    return new Goblin();
                case "Griffin":
                    return new Griffin();
                case "WolfRaider":
                    return new WolfRaider();
                default:
                    return base.CreateCreature(name);
            }
        }
    }
}
