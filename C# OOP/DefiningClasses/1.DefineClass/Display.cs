using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DefineClass
{
    class Display
    {
        int size;
        int numberOfColors;

        public Display(int size, int numColors)
        {
            this.Size = size;
            this.NumberOfColors = numColors;
        }
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                this.size = value;
            }
        }
        public int NumberOfColors
        {
            get
            {
                return numberOfColors;
            }
            set
            {
                this.numberOfColors = value;
            }
        }
        public override string ToString()
        {
            return (Size+" "+ NumberOfColors).ToString();
        }
    }
}
