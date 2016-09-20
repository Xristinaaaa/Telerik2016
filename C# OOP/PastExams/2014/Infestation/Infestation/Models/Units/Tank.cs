namespace Infestation.Models.Units
{
    using System;
    using Infestation.UnitSpec;
    using Infestation.Enums;

    public class Tank : Unit
    {
        const int TankPower = 25;
        const int TankAggression = 25;
        const int TankHealth = 20;

        public Tank(string id) 
            : base(id, UnitClassification.Mechanical, Tank.TankHealth, Tank.TankPower, Tank.TankAggression)
        {
        }
    }
}
