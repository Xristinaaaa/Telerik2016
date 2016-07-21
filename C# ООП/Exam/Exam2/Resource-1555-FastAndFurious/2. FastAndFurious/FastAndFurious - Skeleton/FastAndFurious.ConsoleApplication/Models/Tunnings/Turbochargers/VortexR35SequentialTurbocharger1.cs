using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Tires.Abstract;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers
{
    public class VortexR35SequentialTurbocharger1 : Turbocharger
    {
        private const int VortexR35SequentialTurbocharger1WeightInGrams = 3900;
        private const int VortexR35SequentialTurbocharger1AccelerationBonus = 10;
        private const int VortexR35SequentialTurbocharger1TopSpeedBonus = 85;
        private const decimal VortexR35SequentialTurbocharger1PriceInUSADollars = 699;

        public VortexR35SequentialTurbocharger1()
        {
        }
    }
}
