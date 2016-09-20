﻿namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Infestation.Enums;
    using Infestation.HoldingPenSpec;
    using Infestation.SupplementSpec;
    using Infestation.UnitSpec;

    class Program
    {
        static void Main(string[] args)
        {
            HoldingPen pen = InitializePen();
            StartOperations(pen);
        }

        private static void StartOperations(HoldingPen pen)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                pen.ParseCommand(input);
                input = Console.ReadLine();
            }
        }

        private static HoldingPen InitializePen()
        {
            return new HoldingPenWithSupplements();
        }
    }
}
