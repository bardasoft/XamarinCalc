using Xamarin.Forms.Internals;

namespace XamCalc
{
    [Preserve(AllMembers = true)]
    public class Calculator
    {
        public double? FirstOperator { get; set; }
        public double? SecondOperator { get; set; }

        public double Multiply()
        {
            return FirstOperator.Value * SecondOperator.Value;
        }

        public double Add()
        {
            return FirstOperator.Value + SecondOperator.Value;
        }

        public double Substract()
        {
            return FirstOperator.Value - SecondOperator.Value;
        }

        public double Divide()
        {
            return FirstOperator.Value / SecondOperator.Value;
        }

        public void ClearAll()
        {
            FirstOperator = null;
            SecondOperator = null;
        }
        public void ClearCurrent()
        {
            if (SecondOperator != null)
            {
                SecondOperator = null;
                return;
            }
            FirstOperator = null;
        }
    }
}
