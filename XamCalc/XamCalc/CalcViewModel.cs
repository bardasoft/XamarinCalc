using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamCalc
{
    public class CalcViewModel: BindableObject
    {
        private readonly Calculator _calculator;

        private string _displayText;

        private string _first = string.Empty;
        private string _second = string.Empty;
        private string _func = string.Empty;
        private string _result = string.Empty;
        public CalcViewModel()
        {
            this._calculator = new Calculator();
            this.KeyCommand = new Command<string>(OnButton);
        }
        public string DisplayText
        {
            get { return _displayText; }
            private set { _displayText = value; OnPropertyChanged();}
        }


        public ICommand KeyCommand { get; private set; }

        public void OnButton(string key)
        {
            switch (key)
            {
                case "C":
                    ClearAll();
                    break;
                case "CE":
                    ClearCurrent();
                    break;
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    ProcessDigit(key);
                    break;
                case ".":
                    ProcessDecimalSeparator();
                    break;
                case "=":
                    ProcessRequestCalc();
                    break;
                case "%":
                case "-":
                case "+":
                case "X":
                    ProcessOperator(key);
                    break;
            }

            CalculateDisplay();
        }

        private void ClearCurrent()
        {
            _calculator.ClearCurrent();
            if (!string.IsNullOrEmpty(_second))
            {
                _second = string.Empty;
            }
            else
            {
                _first = string.Empty;
            }
        }

        private void ClearAll()
        {
            _calculator.ClearAll();
            _first = string.Empty;
            _second = string.Empty;
            _func = string.Empty;
            _result = string.Empty;
        }

        private void ProcessOperator(string key)
        {
            if (string.IsNullOrEmpty(_first)) return;
            _func = key;
        }

        private void ProcessDecimalSeparator()
        {
            //check if possible
            if (IsValidForDecimal(_second))
            {
                    _second += ".";
                
            }
            else if(IsValidForDecimal(_first))
            {
                _first += ".";
            }
        }

        private bool IsValidForDecimal(string number)
        {
            if (string.IsNullOrEmpty(number)) return false;
            
            if (number.Contains(".") || !Char.IsDigit(number.ToCharArray().Last())) return false;

            return true;
        }

        private void ProcessRequestCalc()
        {
            //check if possible
            if(string.IsNullOrEmpty(_first))return;
            if (string.IsNullOrEmpty(_second)) return;
            if (string.IsNullOrEmpty(_func)) return;

            _first = string.Empty;
            _second = string.Empty;

            var result = 0.0;
            switch (_func)
            {
                case "%":
                    result = _calculator.Divide();
                break;
                case "X":
                    result = _calculator.Multiply();
                    break;
                case "+":
                    result = _calculator.Add();
                    break;
                case "-":
                    result = _calculator.Substract();
                    break;
            }
            _func = string.Empty;
            _result = FormatResult(result);
        }

        private static string FormatResult(double result)
        {
            if (double.IsNaN(result) || double.IsInfinity(result))
            {
                return "ERROR - Division by Zero is not allowed";
            }
            return result.ToString();
        }

        private void ProcessDigit(string key)
        {
            if (string.IsNullOrEmpty(_func))
            {
                _first += key;
                _calculator.FirstOperator = double.Parse(_first);
            }
            else
            {
                _second += key;
                _calculator.SecondOperator = double.Parse(_second);
            }
            _result = string.Empty;
        }

        private void CalculateDisplay()
        {
            if (!string.IsNullOrEmpty(_result))
            {
                DisplayText = _result; return;
            }

            if (string.IsNullOrEmpty(_first))
            {
                DisplayText = string.Empty;
            }

            var display = _first;

            if (!string.IsNullOrEmpty(_func))
            {
                display += Environment.NewLine;
                display += _func;
            }

            if (!string.IsNullOrEmpty(_second))
            {
                display += Environment.NewLine;
                display += _second;
            }

            DisplayText = display;
        }
    }
}