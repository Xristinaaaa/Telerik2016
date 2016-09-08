using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chef.Models
{
    public class Potato : Vegetable
    {
        public Potato(string color, string price, string growingPlace, string use) 
            : base(color, price, growingPlace, use)
        {
        }
    }
}
