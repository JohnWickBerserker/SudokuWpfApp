using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWpfApp.ViewModels
{
    class MainViewModel
    {
        public MainViewModel()
        {
            for (var i = 0; i < SelectorButtons.Length; i++)
            {
                SelectorButtons[i] = new DigitSelectorBtnViewModel { Digit = $"{i + 1}" };
            }
            SelectorButtons[0].IsSelected = true;
        }

        public BoardViewModel Board { get; set; } = new BoardViewModel();

        public DigitSelectorBtnViewModel[] SelectorButtons { get; set; } = new DigitSelectorBtnViewModel[9];

        public bool MainModeIsOn { get; set; } = true;

        public bool HintModeIsOn { get; set; }

        public void OnMainModeMouseDown()
        {
            Trace.WriteLine("event MainMode MouseDown");
        }

        public void OnHintModeMouseDown()
        {
            Trace.WriteLine("event HintMode MouseDown");
        }
    }
}
