using System.ComponentModel;

namespace SudokuWpfApp.ViewModels
{
    class HintViewModel : INotifyPropertyChanged
    {
        public bool IsSet { get; set; }
        public bool IsBreakingRules { get; set; }
        public bool IsHighlighted { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
