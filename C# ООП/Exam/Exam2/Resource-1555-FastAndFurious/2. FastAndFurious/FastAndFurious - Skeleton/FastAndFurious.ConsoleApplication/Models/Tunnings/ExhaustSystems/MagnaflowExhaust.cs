using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class MagnaflowExhaust : Exhaust
    {
        private const int MagnaflowExhaustWeightInGrams = 12800;
        private const int MagnaflowExhaustAccelerationBonus = 5;
        private const int MagnaflowExhaustTopSpeedBonus = 25;
        private const decimal MagnaflowExhaustPriceInUSADollars = 379;

        public MagnaflowExhaust(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, ExhaustType exhaustType) : base(price, weight, acceleration, topSpeed, gradeType, exhaustType)
        {
        }
    }
}
