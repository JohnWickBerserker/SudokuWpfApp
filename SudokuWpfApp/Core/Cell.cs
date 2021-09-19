using System;
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
        public bool IsFixed => _fixed;
        public IReadOnlySet<int> Hints => _hints;

        public event Action<Cell> DigitChanged;
        public event Action<Cell> FixedChanged;
        public event Action<Cell> HintsChanged;

        public void SetDigit(int digit)
        {
            this._digit = digit;
            DigitChanged?.Invoke(this);
        }
        public void RemoveDigit()
        {
            this._digit = default;
            DigitChanged?.Invoke(this);
        }

        public void FixDigit()
        {
            _fixed = true;
            FixedChanged?.Invoke(this);
        }
        public void UnfixDigit()
        {
            _fixed = false;
            FixedChanged?.Invoke(this);
        }

        public void SetHint(int digit)
        {
            _hints.Add(digit);
            HintsChanged?.Invoke(this);
        }
        public void RemoveHint(int digit)
        {
            _hints.Remove(digit);
            HintsChanged?.Invoke(this);
        }
    }
}
