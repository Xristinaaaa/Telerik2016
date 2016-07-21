using FastAndFurious.ConsoleApplication.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract
{
    public abstract class Intercooler :  ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable, IIntercooler
    {
        private readonly Intercooler intercooler;

        public Intercooler(
           decimal price,
           int weight,
           int acceleration,
           int topSpeed,
           TunningGradeType gradeType,
           Intercooler intercooler)
        {
            this.intercooler = intercooler;
        }

        public int Acceleration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IntercoolerType IntercoolerType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal Price
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int TopSpeed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Weight
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        TunningGradeType ITunningPart.GradeType
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
