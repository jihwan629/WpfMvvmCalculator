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
        string inputString = "";
        string displayText = "";

        public event PropertyChangedEventHandler PropertyChanged;

        // 생성자, 명령 객체 초기화
        // 버튼의 Command와 바인딩
        public CalcViewModel()
        {
            this.Append     = new Append(this);
            this.Backspace  = new Backspace(this);
            this.Clear      = new Clear(this);
            this.Operator   = new Operator(this);
            this.Calculate  = new Calculate(this);

        }

        public string InputString
        {
            internal set
            {
                if(inputString != value)
                {
                    inputString = value;
                    OnPropertyChanged("InputString");

                    this.DisplayText = value;
                }
            }
            get { return inputString; }
        }

        // 출력창 바인딩
        public string DisplayText
        {
            protected set
            {
                if(displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }
            }
            get { return displayText; }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // 연산자 저장
        public string Op { get; set; }
        // 이전 숫자 저장
        public double? Op1 { get; set; }

        // 커맨드 오브젝트
        public ICommand Append { protected set; get; }
        public ICommand Backspace { protected set; get; }
        public ICommand Clear { protected set; get; }
        public ICommand Operator { protected set; get; }
        public ICommand Calculate { protected set; get; }

    }
}
