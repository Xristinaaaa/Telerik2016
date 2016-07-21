using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class EvolutionXPerformanceIntercooler : Intercooler
    {
        private const int EvolutionXPerformanceIntercoolerWeightInGrams = 4500;
        private const int EvolutionXPerformanceIntercoolerAccelerationBonus = -5;
        private const int EvolutionXPerformanceIntercoolerTopSpeedBonus = 40;
        private const decimal EvolutionXPerformanceIntercoolerPriceInUSADollars = 499;
        
        public EvolutionXPerformanceIntercooler(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, Intercooler intercooler) : base(price, weight, acceleration, topSpeed, gradeType, intercooler)
        {
        }
    }
}
