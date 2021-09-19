using System.ComponentModel;
using System.Linq;

namespace SudokuWpfApp.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int selectedDigit;

        public MainViewModel()
        {
            Board = new BoardViewModel(this);
            var example = Examples.Examples.GetExample();
            Board.ApplyExample(Core.Board.FromArray(example));
            for (var i = 0; i < SelectorButtons.Length; i++)
            {
                SelectorButtons[i] = new DigitSelectorBtnViewModel(this) { Digit = i + 1 };
            }
            SelectDigit(1);
            UpdateHighlight();
        }

        public BoardViewModel Board { get; set; }

        public DigitSelectorBtnViewModel[] SelectorButtons { get; set; } = new DigitSelectorBtnViewModel[9];

        public bool MainModeIsOn { get; set; } = true;

        public bool HintModeIsOn { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SelectDigit(int digit)
        {
            foreach (var i in SelectorButtons)
            {
                i.IsSelected = i.Digit == digit;
            }
            selectedDigit = digit;
            UpdateHighlight();
        }

        public void OnCellMouseDown(CellViewModel cell)
        {
            if (MainModeIsOn)
            {
                OnCellMouseDownWhenMainMode(cell);
            }
            else
            {
                OnCellMouseDownWhenHintMode(cell);
            }
            UpdateBreakingRule(cell);
        }

        public void OnMainModeMouseDown()
        {
            MainModeIsOn = true;
            HintModeIsOn = false;
        }

        public void OnHintModeMouseDown()
        {
            MainModeIsOn = false;
            HintModeIsOn = true;
        }

        private void OnCellMouseDownWhenMainMode(CellViewModel cell)
        {
            if (!cell.Core.IsFixed)
            {
                if (cell.Core.HasDigit && cell.Core.Digit == selectedDigit)
                {
                    cell.Core.RemoveDigit();
                    cell.HintsIsVisible = true;
                    cell.IsHighlighted = false;
                }
                else
                {
                    cell.Core.SetDigit(selectedDigit);
                    cell.HintsIsVisible = false;
                    cell.IsHighlighted = true;
                }
            }
        }

        private void OnCellMouseDownWhenHintMode(CellViewModel cell)
        {
            if (!cell.Core.IsFixed)
            {
                if (!cell.Core.HasDigit)
                {
                    if (cell.Core.Hints.Contains(selectedDigit))
                    {
                        cell.Core.RemoveHint(selectedDigit);
                        cell.GetHint(selectedDigit).IsHighlighted = false;
                    }
                    else
                    {
                        cell.Core.SetHint(selectedDigit);
                        cell.GetHint(selectedDigit).IsHighlighted = true;
                    }
                }
            }
        }

        private void UpdateHighlight()
        {
            foreach (var m in Board.Matrix3x3)
            {
                foreach (var c in m.Cells)
                {
                    c.IsHighlighted = c.Core.HasDigit && c.Core.Digit == selectedDigit;
                    foreach (var h in c.Hints)
                    {
                        h.IsHighlighted = false;
                    }
                    c.GetHint(selectedDigit).IsHighlighted = true;
                }
            }
        }

        private void UpdateBreakingRule(CellViewModel cell)
        {
            var relatedCells = Board.Core.GetCellsRelatedTo(cell.Core);
            var cellsBreakRule = Board.Core.GetCellsBreakRule(cell.Core, selectedDigit);
            var cellsWithHintBreakRule = Board.Core.GetCellsWithHintThatBreakRule(cell.Core, selectedDigit);
            foreach (var m in Board.Matrix3x3)
            {
                foreach (var c in m.Cells)
                {
                    if (relatedCells.Contains(c.Core))
                    {
                        if (c.Core.HasDigit && c.Core.Digit == selectedDigit)
                        {
                            c.IsBreakingRules = cellsBreakRule.Contains(c.Core);
                        }
                        c.GetHint(selectedDigit).IsBreakingRules = cellsWithHintBreakRule.Contains(c.Core);
                    }
                }
            }
        }
    }
}
