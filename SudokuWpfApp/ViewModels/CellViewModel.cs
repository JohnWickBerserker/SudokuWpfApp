using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWpfApp.ViewModels
{
    class CellViewModel
    {
        public bool HasDigit { get; set; }
        public int Digit { get; set; }
        public bool IsFixed { get; set; }
        public bool IsBreakingRules { get; set; }
        public bool IsHighlighted { get; set; }
        public Dictionary<int, HintViewModel> Hints { get; set; } = new Dictionary<int, HintViewModel>();
        // event MouseEnter - viewmodel responsibility
        // event MouseLeave - viewmodel responsibility
        // event MouseClick - involves logic
    }
}
