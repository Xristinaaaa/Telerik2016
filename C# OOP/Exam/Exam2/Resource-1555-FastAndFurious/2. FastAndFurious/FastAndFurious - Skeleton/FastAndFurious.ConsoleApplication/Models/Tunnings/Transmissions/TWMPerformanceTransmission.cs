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
    public class TWMPerformanceTransmission : Transmission
    {
        private const int TWMPerformanceTransmissionWeightInGrams = 4799;
        private const int TWMPerformanceTransmissionAccelerationBonus = 15;
        private const int TWMPerformanceTransmissionTopSpeedBonus = 0;
        private const decimal TWMPerformanceTransmissionPriceInUSADollars = 1599;

        public TWMPerformanceTransmission()
        {
        }
    }
}
