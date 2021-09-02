using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWpfApp.ViewModels
{
    class HintViewModel
    {
        public bool IsSet { get; set; }
        public bool IsBreakingRules { get; set; }
        public bool IsHighlighted { get; set; }
    }
}
