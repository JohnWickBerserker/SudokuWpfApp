using SudokuWpfApp.Core;
using System.ComponentModel;

namespace SudokuWpfApp.ViewModels
{
    class CellViewModel : INotifyPropertyChanged
    {
        private MainViewModel main;
        private Cell cellCore;
        
        public CellViewModel(MainViewModel main)
        {
            this.main = main;
            for (var i = 0; i < 9; i++)
            {
                Hints[i] = new HintViewModel { IsSet = false, IsBreakingRules = false };
            }
        }

        public Cell Core
        {
            get
            {
                return cellCore;
            }
        }

        public string DigitAsString { get; set; }

        public bool IsFixed { get; set; }

        public bool IsBreakingRules { get; set; }

        public bool IsHighlighted { get; set; }

        public bool DigitIsVisible { get; set; }

        public bool HintsIsVisible { get; set; }

        public HintViewModel[] Hints { get; set; } = new HintViewModel[9];

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnCellMouseDown()
        {
            main.OnCellMouseDown(this);
        }

        public HintViewModel GetHint(int digit)
        {
            return Hints[digit - 1];
        }

        public void Bind(Cell cell)
        {
            if (cellCore != null)
            {
                cellCore.DigitChanged -= CellCoreDigitChanged;
                cellCore.FixedChanged -= CellCoreFixedChanged;
                cellCore.HintsChanged -= CellCoreHintsChanged;
            }
            cellCore = cell;
            cellCore.DigitChanged += CellCoreDigitChanged;
            cellCore.FixedChanged += CellCoreFixedChanged;
            cellCore.HintsChanged += CellCoreHintsChanged;
            ApplyCellCoreProps();
        }

        private void ApplyCellCoreProps()
        {
            if (cellCore.HasDigit)
            {
                DigitAsString = cellCore.Digit.ToString();
            }
            DigitIsVisible = cellCore.HasDigit;
            HintsIsVisible = !cellCore.HasDigit;
            IsFixed = cellCore.IsFixed;
        }

        private void CellCoreDigitChanged(Cell cell)
        {
            if (cellCore.HasDigit)
            {
                DigitAsString = cellCore.Digit.ToString();
            }
            DigitIsVisible = cellCore.HasDigit;
        }

        private void CellCoreFixedChanged(Cell cell)
        {
            IsFixed = cellCore.IsFixed;
        }

        private void CellCoreHintsChanged(Cell cell)
        {
            for (var i = 0; i < 9; i++)
            {
                Hints[i].IsSet = cellCore.Hints.Contains(i + 1);
            }
        }
    }
}