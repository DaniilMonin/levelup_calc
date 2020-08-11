﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math.Calculator.Console;
using Math.Calculator.Core;
using Math.Calculator.Standard;

namespace Math.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardCalculator standardCalculator = new StandardCalculator("Std", new ConsoleInputManager(), new ConsoleResultOutputManager());

            standardCalculator.Start();

            /*standardCalculator.Operators[0].Execute();

            standardCalculator.Operators[0].Execute();*/

        }
    }
}
