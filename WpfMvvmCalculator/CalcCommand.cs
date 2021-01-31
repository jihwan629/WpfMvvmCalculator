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
                c.InputString = c.DisplayText = "";
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
            c.InputString = c.DisplayText = "";
            c.Op1 = null;
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

    class CalcCommand
    {
    }
}
