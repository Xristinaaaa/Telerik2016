namespace Infestation.UnitSpec
{
    using System;
    using Infestation.Enums;

    public class Interaction
    {
        public const Interaction PassiveInteraction = null;

        public UnitInfo SourceUnit { get; private set; }
        public UnitInfo TargetUnit { get; private set; }
        public InteractionType InteractionType { get; private set; }

        public Interaction(UnitInfo sourceUnitInfo, UnitInfo targetUnitInfo, InteractionType type)
        {
            this.SourceUnit = sourceUnitInfo;
            this.TargetUnit = targetUnitInfo;
            this.InteractionType = type;
        }
    }
}
