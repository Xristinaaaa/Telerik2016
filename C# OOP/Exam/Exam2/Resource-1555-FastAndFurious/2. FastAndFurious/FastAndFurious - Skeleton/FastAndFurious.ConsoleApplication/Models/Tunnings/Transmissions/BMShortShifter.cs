using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Tires.Abstract;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
    public class BMShortShifter : Transmission
    {
        private const int BMShortShifterWeightInGrams = 5700;
        private const int BMShortShifterAccelerationBonus = 28;
        private const int BMShortShifterTopSpeedBonus = 0;
        private const decimal BMShortShifterPriceInUSADollars = 2799;

        public BMShortShifter()
        {
        }
    }
}
