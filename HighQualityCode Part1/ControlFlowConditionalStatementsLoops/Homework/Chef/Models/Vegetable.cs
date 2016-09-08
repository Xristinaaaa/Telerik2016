using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chef.Models
{
    public class Vegetable
    {
        string color;
        string price;
        string placeToGrow;
        string use;
        
        public Vegetable(string color, string price, string growingPlace, string use)
        {
            this.color = color;
            this.price = price;
            this.placeToGrow = growingPlace;
            this.use = use;
        } 
    }
}
