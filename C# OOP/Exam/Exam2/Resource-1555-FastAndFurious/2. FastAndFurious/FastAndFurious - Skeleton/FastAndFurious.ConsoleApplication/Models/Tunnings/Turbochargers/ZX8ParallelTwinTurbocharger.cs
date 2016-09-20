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
    public class ZX8ParallelTwinTurbocharger : Turbocharger
    {      
        private const int ZX8ParallelTwinTurbochargerWeightInGrams = 3500;
        private const int ZX8ParallelTwinTurbochargerAccelerationBonus = 15;
        private const int ZX8ParallelTwinTurbochargerTopSpeedBonus = 60;
        private const decimal ZX8ParallelTwinTurbochargerPriceInUSADollars = 799;

        public ZX8ParallelTwinTurbocharger()
        {
        }       
    }
}
