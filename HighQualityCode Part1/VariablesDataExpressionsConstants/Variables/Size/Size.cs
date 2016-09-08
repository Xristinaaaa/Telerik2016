using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Size
{
    public class Size
    {
        public double width, height;

        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static Size GetRotatedSize(Size size, double angleOfFigure)
        {
            return new Size(Math.Abs(Math.Cos(angleOfFigure)) * size.width + Math.Abs(Math.Sin(angleOfFigure)) * size.height,
                            Math.Abs(Math.Sin(angleOfFigure)) * size.width + Math.Abs(Math.Cos(angleOfFigure)) * size.height);
        }
    }
}
