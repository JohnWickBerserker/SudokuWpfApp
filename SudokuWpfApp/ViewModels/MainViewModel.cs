using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWpfApp.ViewModels
{
    class MainViewModel
    {
        public BoardViewModel Board { get; set; } = new BoardViewModel();
    }
}
