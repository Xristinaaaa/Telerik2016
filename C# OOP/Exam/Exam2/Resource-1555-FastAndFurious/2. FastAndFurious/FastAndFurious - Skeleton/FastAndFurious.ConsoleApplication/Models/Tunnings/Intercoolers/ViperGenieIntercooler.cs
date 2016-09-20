using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class ViperGenieIntercooler : Intercooler
    {
        private const int ViperGenieIntercoolerWeightInGrams = 5300;
        private const int ViperGenieIntercoolerAccelerationBonus = 0;
        private const int ViperGenieIntercoolerTopSpeedBonus = 25;
        private const decimal ViperGenieIntercoolerPriceInUSADollars = 289;

        public ViperGenieIntercooler(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, Intercooler intercooler) : base(price, weight, acceleration, topSpeed, gradeType, intercooler)
        {
        }
    }
}
