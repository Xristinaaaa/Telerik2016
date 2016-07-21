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
    public class HurstCompetitionManualShifter : Transmission
    {
        private const int HurstCompetitionManualShifterWeightInGrams = 6000;
        private const int HurstCompetitionManualShifterAccelerationBonus = 20;
        private const int HurstCompetitionManualShifterTopSpeedBonus = 0;
        private const decimal HurstCompetitionManualShifterPriceInUSADollars = 1999;

        public HurstCompetitionManualShifter()
        {
        }
    }
}
