using System.Diagnostics;

namespace SudokuWpfApp.ViewModels
{
    class DigitSelectorBtnViewModel
    {
        public string Digit { get; set; }

        public bool IsSelected { get; set; }

        public void OnMouseDown()
        {
            Trace.WriteLine("event DigitSelectorBtn MouseDown");
        }
    }
}
