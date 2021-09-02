using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWpfApp.ViewModels
{
    class BoardViewModel
    {
        public Matrix3x3ViewModel[] Matrix3x3 { get; set; } = new Matrix3x3ViewModel[9];

        public BoardViewModel()
        {
            for (var i = 0; i < Matrix3x3.Length; i++)
            {
                Matrix3x3[i] = new Matrix3x3ViewModel();
            }
            int[,] example =
            {
                { 0, 5, 0, 0, 0, 8, 2, 6, 9 },
                { 0, 0, 2, 0, 4, 3, 0, 0, 0 },
                { 0, 0, 9, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 7, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 9, 0, 0, 4, 0 },
                { 5, 0, 3, 0, 0, 0, 0, 9, 0 },
                { 0, 0, 0, 0, 2, 4, 6, 0, 5 },
                { 6, 0, 0, 0, 0, 0, 0, 0, 3 },
                { 0, 4, 0, 0, 8, 0, 0, 0, 0 },
            };
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    int matrixIndex = (i / 3) * 3 + (j / 3);
                    int cellIndex = (i % 3) * 3 + (j % 3);
                    var cell = Matrix3x3[matrixIndex].Cells[cellIndex];
                    cell.DigitAsString = example[i, j] == 0 ? string.Empty : example[i, j].ToString();
                    cell.IsFixed = example[i, j] != 0;
                    cell.DigitIsVisible = example[i, j] != 0;
                }
            }
            Matrix3x3[8].Cells[3].DigitAsString = "4";
            Matrix3x3[8].Cells[3].DigitIsVisible = true;
            Matrix3x3[0].Cells[0].DigitAsString = "5";
            Matrix3x3[0].Cells[0].IsBreakingRules = true;
            Matrix3x3[0].Cells[0].DigitIsVisible = true;
            Matrix3x3[0].Cells[0].IsHighlighted = true;

            Matrix3x3[0].Cells[4].HintsIsVisible = true;
            Matrix3x3[0].Cells[4].Hints[3].IsSet = true;
            Matrix3x3[0].Cells[4].Hints[3].IsBreakingRules = true;
            Matrix3x3[0].Cells[4].Hints[3].IsHighlighted = true;
        }
    }
}
