namespace Infestation.HoldingPenSpec
{
    using Infestation.SupplementSpec;
    using Infestation.Models.Supplements;
    using System;
    using Infestation.UnitSpec;
    using Infestation.Models.Units;
    using Infestation.Enums;

    public class HoldingPenWithSupplements : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            //insert Tank Tanio
            var unitType = commandWords[1];
            var unitId = commandWords[2];

            Unit unitToBeAdded = null; 
            switch (unitType)
            {
                case "Marine":
                    unitToBeAdded = new Marine(unitId);
                    break;
                case "Queen":
                    unitToBeAdded = new Queen(unitId);
                    break;
                case "Parasite":
                    unitToBeAdded = new Parasite(unitId);
                    break;
                case "Tank":
                    unitToBeAdded = new Tank(unitId);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }

            if (unitToBeAdded!=null)
            {
                this.InsertUnit(unitToBeAdded);
            }
            base.ExecuteInsertUnitCommand(commandWords);    
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            //supplement AggressionInhibitor sharo

            var supplementType = commandWords[1];
            ISupplement supplement=null;

            switch (supplementType)
            {
                case "AggressionCatalyst":
                    supplement = new AggressionCatalyst();
                    break;
                case "HealthCatalyst":
                    supplement = new HealthCatalyst();
                    break;
                case "PowerCatalyst":
                    supplement = new PowerCatalyst();
                    break;
                case "Weapon":
                    supplement = new Weapon();
                    break;
                default:
                    break;
            }

            var unitId = commandWords[2];
            var unit=this.GetUnit(unitId);

            if (unit!=null)
            {
                unit.AddSupplement((Supplement)supplement);
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            //Infesting is equivalent to adding an InfestationSpores Supplement to the target
            if (interaction.InteractionType == InteractionType.Infest)
            {
                var unit = this.GetUnit(interaction.TargetUnit.Id);
                unit.AddSupplement(new InfestationSpores());
            }
            else
            {
                base.ProcessSingleInteraction(interaction);
            }
        }
    }
}
