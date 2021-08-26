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
    }
}
