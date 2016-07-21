namespace Infestation.Models.Units
{
    using System;
    using Infestation.UnitSpec;
    using Infestation.Models.Supplements;
    using System.Collections.Generic;
    using System.Linq;

    public class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            //The target’s Power is less than or equal to the Marine’s Aggression

            if(this.Id == unit.Id)
            {
                return false;
            }
            if (unit.Power<= this.Aggression)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            return attackableUnits.OrderByDescending(Unit => Unit.Health)
                                  .FirstOrDefault();              
        }
    }
}
