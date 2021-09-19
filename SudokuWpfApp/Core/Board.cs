using System.Collections.Generic;
using System.Linq;

namespace SudokuWpfApp.Core
{
    class Board
    {
        private Cell[,] _cells = new Cell[9, 9];

        public static Board FromArray(int[,] array)
        {
            var result = new Board();
            for (var i = 0; i <= CellPosition.MaxRowIndex; i++)
            {
                for (var j = 0; j <= CellPosition.MaxColumnIndex; j++)
                {
                    if (array[i, j] != 0)
                    {
                        var cell = result.GetCell(i, j);
                        cell.SetDigit(array[i, j]);
                        cell.FixDigit();
                    }
                }
            }
            return result;
        }

        public Board()
        {
            for (var i = 0; i <= CellPosition.MaxRowIndex; i++)
            {
                for (var j = 0; j <= CellPosition.MaxColumnIndex; j++)
                {
                    _cells[i, j] = new Cell();
                }
            }
        }

        public Cell GetCell(CellPosition pos)
        {
            return _cells[pos.RowIndex, pos.ColumnIndex];
        }

        public Cell GetCell(int rowIndex, int columnIndex)
        {
            return GetCell(new CellPosition(rowIndex, columnIndex));
        }

        
        public IEnumerable<Cell> GetCellsBreakRule(CellPosition pos, int digit)
        {
            var cellsWithTheDigit = GetCellsRelatedTo(pos).Where(x => x.HasDigit && x.Digit == digit).ToList();
            return cellsWithTheDigit.Where(x => CellIsBreakingRule(x)).ToList();
        }

        private bool CellIsBreakingRule(Cell cell)
        {
            var digit = cell.Digit;
            return WillDigitBreakRule(cell, digit);
        }

        private bool WillDigitBreakRule(CellPosition pos, int digit)
        {
            var cellsBreakRule = new HashSet<Cell>();
            AddToSet(GetRow(pos.RowIndex).GetCellsWithDigit(digit), cellsBreakRule);
            AddToSet(GetColumn(pos.ColumnIndex).GetCellsWithDigit(digit), cellsBreakRule);
            AddToSet(GetSquare(pos.RowIndex, pos.ColumnIndex).GetCellsWithDigit(digit), cellsBreakRule);
            cellsBreakRule.Remove(GetCell(pos));
            return cellsBreakRule.Count > 0;
        }

        private bool WillDigitBreakRule(Cell cell, int digit)
        {
            var pos = GetCellPosition(cell);
            return WillDigitBreakRule(pos, digit);
        }

        public IEnumerable<Cell> GetCellsBreakRule(Cell cell, int digit)
        {
            var pos = GetCellPosition(cell);
            return GetCellsBreakRule(pos, digit);
        }

        public IEnumerable<Cell> GetCellsWithHintThatBreakRule(CellPosition pos, int hintDigit)
        {
            var cellsWithTheHint = GetCellsRelatedTo(pos).Where(x => x.Hints.Contains(hintDigit)).ToList();
            return cellsWithTheHint.Where(x => WillDigitBreakRule(x, hintDigit)).ToList();
        }

        public IEnumerable<Cell> GetCellsWithHintThatBreakRule(Cell cell, int hintDigit)
        {
            var pos = GetCellPosition(cell);
            return GetCellsWithHintThatBreakRule(pos, hintDigit);
        }

        public IEnumerable<Cell> GetCellsRelatedTo(CellPosition pos)
        {
            var cells = new HashSet<Cell>();
            AddToSet(GetRow(pos.RowIndex), cells);
            AddToSet(GetColumn(pos.ColumnIndex), cells);
            AddToSet(GetSquare(pos.RowIndex, pos.ColumnIndex), cells);
            return cells.ToList();
        }

        public IEnumerable<Cell> GetCellsRelatedTo(Cell cell)
        {
            var pos = GetCellPosition(cell);
            return GetCellsRelatedTo(pos);
        }

        private static void AddToSet<T>(IEnumerable<T> items, ISet<T> set)
        {
            foreach (var i in items)
            {
                set.Add(i);
            }
        }

        private RelatedCells GetRow(int rowIndex)
        {
            var cells = new List<Cell>();
            for (var i = 0; i <= CellPosition.MaxColumnIndex; i++)
            {
                cells.Add(GetCell(rowIndex, i));
            }
            return new RelatedCells(cells);
        }

        private RelatedCells GetColumn(int columnIndex)
        {
            var cells = new List<Cell>();
            for (var i = 0; i <= CellPosition.MaxRowIndex; i++)
            {
                cells.Add(GetCell(i, columnIndex));
            }
            return new RelatedCells(cells);
        }

        private RelatedCells GetSquare(int rowIndex, int columnIndex)
        {
            var squareRow = rowIndex / 3;
            var squareColumn = columnIndex / 3;
            var cells = new List<Cell>();
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    cells.Add(GetCell(squareRow * 3 + i, squareColumn * 3 + j));
                }
            }
            return new RelatedCells(cells);
        }

        private CellPosition GetCellPosition(Cell cell)
        {
            for (int i = 0; i <= CellPosition.MaxRowIndex; i++)
            {
                for (int j = 0; j <= CellPosition.MaxColumnIndex; j++)
                {
                    if (cell == _cells[i, j])
                    {
                        return new CellPosition(i, j);
                    }
                }
            }
            return CellPosition.Invalid;
        }
    }
}
