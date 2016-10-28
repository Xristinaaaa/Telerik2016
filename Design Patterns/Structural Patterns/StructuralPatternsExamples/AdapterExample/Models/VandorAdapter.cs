using AdapterExample.Contract;
using System.Collections.Generic;

namespace AdapterExample.Models
{
    class VendorAdapter : ITarget
    {
        public List<string> GetProducts()
        {
            VendorAdaptee adaptee = new VendorAdaptee();
            return adaptee.GetListOfProducts();
        }
    }

}
