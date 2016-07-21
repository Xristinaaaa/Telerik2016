namespace Infestation.Models.Supplements
{
    using System;
    using Infestation.SupplementSpec;

    public class Weapon : EffectableSupplement
    {
        public Weapon() 
            : base(10, 0, 3)
        {
            this.hasEffect = false;
        }

        public override void ReactTo(Supplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.hasEffect = true;
            }
        }
    }
}
