using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    class ClassTemplate
    {
        const int maxCount = 6;

        public class ValidationClass
        {
            public void InputText(bool showText)
            {
                string stringBuilder = showText.ToString();
                Console.WriteLine(stringBuilder);
            }
        }

        public static void Startup()
        {
            ValidationClass classToCheck = new ValidationClass();
            classToCheck.InputText(true);
        }
    }
}
