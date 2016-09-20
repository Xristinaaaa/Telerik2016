namespace Infestation.Models.Supplements
{
    using SupplementSpec;
    using System;

    public abstract class Catalyst : Supplement
    {
        public Catalyst(int powerEffect, int healthEffect, int aggressionEffect) 
            : base(powerEffect, healthEffect, aggressionEffect)
        {

        }
    }
}
