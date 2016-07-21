namespace ArmyOfCreatures.Extended.Specialties
{
    using Logic.Battles;
    using Logic.Specialties;
    using System;
    using System.Globalization;
    using Extended.Common;

    public class AddAttackWhenSkip : Specialty
    {
        private const int PointMin = 1;
        private const int PointMax = 10;

        private readonly int points;

        public AddAttackWhenSkip(int points)
        {
            Validator.CheckIfOutOfRange(points, PointMin, PointMax, "Point out of range!");
            this.points = points;
        }

        public  void ApplyWhenSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }
            skipCreature.PermanentAttack += this.points;
        }

        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "{0}({1})", 
                base.ToString(), this.points);
        }
    }
}
