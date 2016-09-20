namespace Infestation.Models.Units
{
    using System;
    using Enums;
    using UnitSpec;

    public class Queen : InfestingUnit
    {
        public Queen(string id)
            : base(id, UnitClassification.Psionic, 30, 1, 1)
        {
        }
    }
}
