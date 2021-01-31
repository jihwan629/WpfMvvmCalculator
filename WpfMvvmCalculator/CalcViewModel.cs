using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvmCalculator
{
    public class CalcViewModel : INotifyPropertyChanged
    {
        string inputText = "";
        string displayText = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public CalcViewModel()
        {
        }

    }
}
