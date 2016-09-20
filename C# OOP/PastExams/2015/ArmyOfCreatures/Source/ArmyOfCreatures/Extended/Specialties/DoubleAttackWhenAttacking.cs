namespace ArmyOfCreatures.Extended.Specialties
{
    using Logic.Specialties;
    using Logic.Battles;
    using Extended.Common;
    using System;

    public class DoubleAttackWhenAttacking : Specialty
    {
        private int rounds;

        public DoubleAttackWhenAttacking(int rounds)
        {
            Validator.CheckIfOutOfRange(rounds, 0, int.MaxValue, "Rounds should be greater than 0!");
            this.rounds = rounds;
        }
        public void ApplyWhenAttacking(ICreaturesInBattle attacker)
        {
            if (attacker==null)
            {
                throw new ArgumentNullException("attacker");
            }
            if (rounds <= 0)
            {
                return;
            }

            attacker.CurrentAttack *= 2;
            this.rounds--;
        }

        public override string ToString()
        {
            return String.Format("{0}({1})", 
                base.ToString(), this.rounds);
        }
    }
}
