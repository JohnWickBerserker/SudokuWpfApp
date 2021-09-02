using System;
using System.Diagnostics;
using System.Windows.Input;

namespace SudokuWpfApp.ViewModels
{
    class CellViewModel
    {
        public CellViewModel()
        {
            for (var i = 0; i < 9; i++)
            {
                Hints[i] = new HintViewModel { IsSet = false, IsBreakingRules = false };
            }
        }

        public string DigitAsString { get; set; }

        public bool IsFixed { get; set; }

        public bool IsBreakingRules { get; set; }

        public bool IsHighlighted { get; set; }

        public bool DigitIsVisible { get; set; }

        public bool HintsIsVisible { get; set; }

        public HintViewModel[] Hints { get; set; } = new HintViewModel[9];

        public void OnCellMouseDown()
        {
            Trace.WriteLine("event Cell MouseDown");
        }
    }
}
