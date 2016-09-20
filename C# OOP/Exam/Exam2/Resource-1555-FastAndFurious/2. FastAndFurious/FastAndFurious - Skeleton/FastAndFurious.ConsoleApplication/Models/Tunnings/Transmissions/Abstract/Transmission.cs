using FastAndFurious.ConsoleApplication.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract
{
    public abstract class Transmission : ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable, ITransmission
    {
        private readonly Transmission transmissiontype;

        public Transmission()
        {
            
        }

        public int Acceleration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TunningGradeType GradeType
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

        public TransmissionType TransmissionType
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
    }
}
