using System;

namespace Math.Calculator.Core.Operators
{
    public interface IDivideCalculationOperator : ICalculationOperator
    {
        double FirstArgument { get; }
        double SecondArgument { get; }
    }


    /*public sealed class UniversalOperator<TArgument> : IDivideCalculationOperator<TArgument>
        where TArgument : struct
    {
        public string DisplayName { get; }
        public void Execute()
        {
            //double val1 = (double) FirstArgument;

            double val11 = (double) Convert.ChangeType(FirstArgument, TypeCode.Double);

            ///var result = FirstArgument / SecondArgument;
        }

        public TArgument FirstArgument { get; set; }
        public TArgument SecondArgument { get; set; }
    }

    public class UniversalNumber
    {
        public int Divide(int i, int i2)
        {
            
        }

        public void Minus()
        {

        }
    }


    public class UserUniversal
    {
        public void Foo()
        {

            UniversalOperator<int> intOper = new UniversalOperator<int>();

            intOper.SecondArgument = 10;

            UniversalOperator<double> dblOper = new UniversalOperator<double>();

            dblOper.FirstArgument = 10.2;
        }
    }*/
}