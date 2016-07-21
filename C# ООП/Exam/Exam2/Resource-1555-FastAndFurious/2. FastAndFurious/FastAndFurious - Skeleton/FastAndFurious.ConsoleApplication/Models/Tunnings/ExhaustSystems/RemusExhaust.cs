using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class RemusExhaust : Exhaust
    {
        private const int RemusExhaustWeightInGrams = 11500;
        private const int RemusExhaustAccelerationBonus = 8;
        private const int RemusExhaustTopSpeedBonus = 32;
        private const decimal RemusExhaustPriceInUSADollars = 679;

        public RemusExhaust(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, ExhaustType exhaustType) : base(price, weight, acceleration, topSpeed, gradeType, exhaustType)
        {
        }
    }
}
