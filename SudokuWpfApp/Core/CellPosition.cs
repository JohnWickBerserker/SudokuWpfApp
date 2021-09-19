namespace SudokuWpfApp.Core
{
    struct CellPosition
    {
        public const int MaxRowIndex = 8;
        public const int MaxColumnIndex = 8;

        public int RowIndex;
        public int ColumnIndex;

        public CellPosition(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        public static CellPosition Invalid => new CellPosition(-1, -1);
    }
}
