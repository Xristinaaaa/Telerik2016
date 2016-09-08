using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chef.Models
{
    public class Bowl
    {
        string material;
        List<Vegetable> vegetables;

        public Bowl(string material)
        {
            this.material = material;
            this.vegetables = new List<Vegetable>();
        }

        public void Add(Vegetable product)
        {
            this.vegetables.Add(product);
        }
    }
}
