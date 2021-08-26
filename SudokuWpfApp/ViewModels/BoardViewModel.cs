using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWpfApp.ViewModels
{
    class BoardViewModel
    {
        public CellViewModel[,] Cells { get; private set; }
    }
}
