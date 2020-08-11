using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fclp;
using Math.Calculator.Core;

namespace Math.Calculator.Console
{
    public class ConsoleInputManager : IInputManager
    {
        public IInputManagerResult Execute(IReadOnlyList<ICalculationOperator> operators)
        {
            ConsoleInputResult result = new ConsoleInputResult(operators);


            /*FluentCommandLineParser<ConsoleInputResult> commandLineParser = new FluentCommandLineParser<ConsoleInputResult>();


            commandLineParser.Setup(arg => arg.FirstArgument)
                .As('f', "first")
                .Required();

            commandLineParser.Setup(arg => arg.SecondArgument)
                .As('s', "second")
                .Required();

            commandLineParser.Setup(arg => arg.IndexOperator)
                .As('o', "operator")
                .Required();


            var resultX = commandLineParser.Parse(new string[]
            {
                "-f 10",
                "-s 20",
                "-o 0",
            });*/

            System.Console.WriteLine("Welcome to clc 2020!");


            double firstArgument = AskForArgument();


            double secondArgument = AskForArgument();

            for (int i = 0; i < operators.Count; i++)
            {
                System.Console.WriteLine($"{i}. As '{operators[i].DisplayName}'");
            }


            System.Console.Write("\r\nEnter operator: ");

            string key = System.Console.ReadLine();

            int indexOperator = Convert.ToInt32(key);

            result.SecondArgument = secondArgument;
            result.FirstArgument = firstArgument;
            result.IndexOperator = indexOperator;

            return result;
        }


        private double AskForArgument()
        {
            System.Console.Write("\r\nEnter argument: ");

            string key = System.Console.ReadLine();

            return Convert.ToDouble(key);
        }

        private sealed class ConsoleInputResult : IInputManagerResult
        {
            private readonly IReadOnlyList<ICalculationOperator> _operators;

            public ConsoleInputResult(IReadOnlyList<ICalculationOperator> operators)
            {
                _operators = operators;
            }

            public double FirstArgument { get; set; }
            public double SecondArgument { get; set; }

            public int IndexOperator { get; set; }

            public Guid IdOperator
            {
                get { return _operators[IndexOperator].Id; }
            }
        }
    }
}
