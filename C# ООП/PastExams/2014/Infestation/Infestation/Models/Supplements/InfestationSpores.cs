namespace Infestation.Models.Supplements
{
    using Infestation.SupplementSpec;
    using System;

    public class InfestationSpores : EffectableSupplement
    {
        public InfestationSpores()
            : base(-1, 0, 20)
        {
            this.hasEffect = true;
        }

        public override void ReactTo(Supplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.hasEffect = false;
            }
        }
    }
}
