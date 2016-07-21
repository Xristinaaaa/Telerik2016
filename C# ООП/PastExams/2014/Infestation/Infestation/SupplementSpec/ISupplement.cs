namespace Infestation.SupplementSpec
{
    using System;

    public interface ISupplement
    {
        void ReactTo(Supplement otherSupplement);
        int PowerEffect { get; }
        int HealthEffect { get; }
        int AggressionEffect { get; }
    }
}
