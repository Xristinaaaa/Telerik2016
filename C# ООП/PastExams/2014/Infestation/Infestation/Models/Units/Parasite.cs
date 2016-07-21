namespace Infestation.Models.Units
{
    using System;
    using Enums;
    using UnitSpec;

    public class Parasite : InfestingUnit
    {
        public Parasite(string id) 
            : base(id, UnitClassification.Biological, 1, 1, 1)
        {

        }
    }
}
