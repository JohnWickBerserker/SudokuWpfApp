namespace SudokuWpfApp.ViewModels
{
    class Matrix3x3ViewModel
    {
        public CellViewModel[] Cells { get; set; } = new CellViewModel[9];
        public Matrix3x3ViewModel()
        {
            for (var i = 0; i < Cells.Length; i++)
            {
                Cells[i] = new CellViewModel();
            }
        }
    }
}