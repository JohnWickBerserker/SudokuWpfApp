using System.Collections.Generic;

namespace SudokuWpfApp.Core
{
    class Cell
    {
        private int _digit;
        private bool _fixed;
        private SortedSet<int> _hints = new SortedSet<int>();

        public int Digit => _digit;
        public bool HasDigit => Digit > 0 && Digit < 10;
        public void SetDigit(int digit) => this._digit = digit;
        public void RemoveDigit() => this._digit = default;

        public bool IsFixed() => _fixed;
        public void FixDigit() => _fixed = true;
        public void UnfixDigit() => _fixed = false;

        public IReadOnlySet<int> Hints => _hints;
        public void SetHint(int digit) => _hints.Add(digit);
        public void RemoveHint(int digit) => _hints.Remove(digit);
    }
}
