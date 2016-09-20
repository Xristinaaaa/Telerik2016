using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class BorlaExhaust : Exhaust
    {
        private const int BorlaExhaustWeightInGrams = 14600;
        private const int BorlaExhaustAccelerationBonus = 12;
        private const int BorlaExhaustTopSpeedBonus = 40;
        private const decimal BorlaExhaustPriceInUSADollars = 1299;

        public BorlaExhaust(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, ExhaustType exhaustType) : base(price, weight, acceleration, topSpeed, gradeType, exhaustType)
        {
        }
    }
}
