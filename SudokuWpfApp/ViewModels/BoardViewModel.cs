using SudokuWpfApp.Core;

namespace SudokuWpfApp.ViewModels
{
    class BoardViewModel
    {
        private Board boardCore;

        public Matrix3x3ViewModel[] Matrix3x3 { get; set; } = new Matrix3x3ViewModel[9];

        public Board Core => boardCore;

        public BoardViewModel(MainViewModel main)
        {
            for (var i = 0; i < Matrix3x3.Length; i++)
            {
                Matrix3x3[i] = new Matrix3x3ViewModel(main);
            }
            boardCore = new Board();
        }

        public void ApplyExample(Board example)
        {
            boardCore = example;
            for (var i = 0; i <= CellPosition.MaxRowIndex; i++)
            {
                for (var j = 0; j <= CellPosition.MaxColumnIndex; j++)
                {
                    int matrixIndex = (i / 3) * 3 + (j / 3);
                    int cellIndex = (i % 3) * 3 + (j % 3);
                    var cell = Matrix3x3[matrixIndex].Cells[cellIndex];
                    cell.Bind(example.GetCell(i, j));
                }
            }
        }
    }
}
