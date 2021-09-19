using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SudokuWpfApp.Core
{
    class RelatedCells : IEnumerable<Cell>
    {
        private List<Cell> _cells;

        internal RelatedCells(IEnumerable<Cell> cells)
        {
            _cells = cells.ToList();
        }

        public IEnumerable<Cell> GetCellsWithDigit(int digit)
        {
            return _cells.Where(x => x.HasDigit && x.Digit == digit).ToList();
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            return _cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cells.GetEnumerator();
        }
    }
}
