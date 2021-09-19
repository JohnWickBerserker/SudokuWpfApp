namespace SudokuWpfApp.ViewModels
{
    class Matrix3x3ViewModel
    {
        public Matrix3x3ViewModel(MainViewModel main)
        {
            for (var i = 0; i < Cells.Length; i++)
            {
                Cells[i] = new CellViewModel(main);
            }
        }

        public CellViewModel[] Cells { get; set; } = new CellViewModel[9];
    }
}