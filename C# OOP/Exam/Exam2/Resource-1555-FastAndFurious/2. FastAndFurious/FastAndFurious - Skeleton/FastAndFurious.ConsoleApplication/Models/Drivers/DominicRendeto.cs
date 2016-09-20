using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class DominicRendeto : Driver
    {
        public DominicRendeto(string name, GenderType gender) : base(name, gender)
        {
        }
    }
}
