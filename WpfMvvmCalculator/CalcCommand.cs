using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvmCalculator
{
    class Backspace : ICommand
    {
        private CalcViewModel c;

        public Backspace(CalcViewModel _c)
        {
            this.c = _c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // displayText 길이가 0이 넘을 때만 실행
        public bool CanExecute(object parameter)
        {
            return c.DisplayText.Length > 0;
        }

        public void Execute(object parameter)
        {
            int length = c.InputString.Length - 1;

            if (length > 0)
                c.InputString = c.InputString.Substring(0, length);
            else
                c.InputString = "";
        }
    }

    class Clear : ICommand
    {
        private CalcViewModel c;

        public Clear(CalcViewModel _c)
        {
            this.c = _c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // displayText 길이가 0이 넘을 때만 실행
        public bool CanExecute(object parameter)
        {
            return c.DisplayText.Length > 0;
        }

        public void Execute(object parameter)
        {
            c.InputString = "";
        }
    }

    class Append : ICommand
    {
        private CalcViewModel c;

        public Append(CalcViewModel _c)
        {
            this.c = _c;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            c.InputString += parameter;
        }
    }

    class Operator : ICommand
    {
        private CalcViewModel c;

        public Operator(CalcViewModel _c)
        {
            this.c = _c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // displayText 길이가 0이 넘을 때만 실행
        public bool CanExecute(object parameter)
        {
            return c.DisplayText.Length > 0;
        }

        public void Execute(object parameter)
        {
            string op = parameter.ToString();
            double op1;

            // InputString이 double로 형변환이 성공적이면 op1에 저장
            if (double.TryParse(c.InputString, out op1))
            {
                c.Op1 = op1;
                c.Op = op;
                c.InputString = "";
            }
            // 음수
            else if(c.InputString == "" && op == "-")
            {
                c.InputString = "-";
            }
        }
    }

    class Calculate : ICommand
    {
        private CalcViewModel c;

        public Calculate(CalcViewModel _c)
        {
            this.c = _c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // displayText 길이가 0이 넘을 때만 실행
        public bool CanExecute(object parameter)
        {
            double op2;
            return c.Op1 != null && double.TryParse(c.InputString, out op2);
        }

        public void Execute(object parameter)
        {
            double op2 = double.Parse(c.InputString);
            c.InputString = calculate(c.Op, (double)c.Op1, op2).ToString();
            c.Op1 = double.Parse(c.InputString);
        }

        private static double calculate(string op, double op1, double op2)
        {
            switch(op)
            {
                case "+": return op1 + op2;
                case "-": return op1 - op2;
                case "*": return op1 * op2;
                case "/": return op1 / op2;
            }

            return 0;
        }
    }

    class CalcCommand
    {
    }
}
