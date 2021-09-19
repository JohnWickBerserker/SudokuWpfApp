using System.ComponentModel;

namespace SudokuWpfApp.ViewModels
{
    class DigitSelectorBtnViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel main;

        public DigitSelectorBtnViewModel(MainViewModel main)
        {
            this.main = main;
        }

        public int Digit { get; set; }

        public bool IsSelected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnMouseDown()
        {
            main.SelectDigit(Digit);
        }
    }
}
