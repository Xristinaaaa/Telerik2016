namespace ArmyOfCreatures.Extended.Specialties
{
    using Logic.Specialties;
    using System;
    using System.Globalization;
    using Extended.Common;

    public class DoubleDamage : Specialty
    {
        private const int RoundMin= 1;
        private const int RoundMax = 10;
        private int rounds;

        public DoubleDamage(int rounds)
        {
            Validator.CheckIfOutOfRange(rounds, RoundMin, RoundMax, "Rounds out of range!");
            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(Logic.Battles.ICreaturesInBattle attackerWithSpecialty,
                                                         Logic.Battles.ICreaturesInBattle defender, decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.rounds <= 0)
            {
                return currentDamage;
            }

            this.rounds--;
            return currentDamage * 2;
        }

        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture,
                "{0}({1})", base.ToString(), this.rounds);   
        }
    }
}
