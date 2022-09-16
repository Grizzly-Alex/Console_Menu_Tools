using static System.Console;


namespace MenuTools.MenuBuilders
{
    public sealed class NumericBuilder : ControlHandlerBuilder
    {
        private (int start, int end) _itemsRange;

        public (int start, int end) ItemsRange
        {
            get { return _itemsRange; }
            set
            {
                if (value.start < value.end)
                {
                    _itemsRange = value;
                }
                else
                {
                    throw new ArgumentException("Start value is equal or more than end value");
                }
            }
        }
        public ConsoleColor NumColor { get; set; } = ConsoleColor.White;
        public ConsoleColor ArowColor { get; set; } = ConsoleColor.White;
        private int CleanSpace => 
            _itemsRange.start.ToString().Length >= _itemsRange.end.ToString().Length ? 
            _itemsRange.start.ToString().Length : _itemsRange.end.ToString().Length;

        public NumericBuilder(int posX, int posY, bool quitOn) : base(posX, posY, quitOn)
        {
        }

        public override void ResetSelectIndex() => _selectedIndex = _itemsRange.start;


        public int RunNumeric(Mod mod)
        {
            ResetSelectIndex();
            bool IsChose = false;

            switch (mod)
            {
                case Mod.Horizontal: DrawNumericHotizontal(_selectedIndex); break;
                case Mod.Vertical: DrawNumericVertical(_selectedIndex); break;
            }

            while (!IsChose)
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed.Equals(mod.Equals(Mod.Horizontal) ? ConsoleKey.RightArrow : ConsoleKey.UpArrow))
                {
                    _selectedIndex++;

                    if (_selectedIndex == _itemsRange.end + 1)
                    {
                        _selectedIndex = _itemsRange.start;
                    }

                }
                else if (keyPressed.Equals(mod.Equals(Mod.Horizontal) ? ConsoleKey.LeftArrow : ConsoleKey.DownArrow))
                {
                    _selectedIndex--;

                    if (_selectedIndex < _itemsRange.start)
                    {
                        _selectedIndex = _itemsRange.end;
                    }
                }
                else if (keyPressed.Equals(ConsoleKey.Escape) && _quitOn) // quit
                {
                    _selectedIndex = _itemsRange.start - 1;
                    IsChose = true;
                }
                else if (keyPressed.Equals(ConsoleKey.Enter)) // choise
                {
                    IsChose = true;
                }

                switch (mod)
                {
                    case Mod.Horizontal: DrawNumericHotizontal(_selectedIndex); break;
                    case Mod.Vertical: DrawNumericVertical(_selectedIndex); break;
                }
            }
            ResetColor();

            return _selectedIndex;
        }

        private void DrawNumericVertical(int index)
        {
            for (int i = 0; i < 3; i++)
            {
                SetCursorPosition(_posX, _posY + i);
                switch (i)
                {
                    case 0: ForegroundColor = ArowColor; Write('▲'); break;
                    case 1: ForegroundColor = NumColor; Write($"{index}{new string(' ', CleanSpace)}"); break;
                    case 2: ForegroundColor = ArowColor; Write('▼'); break;
                }
            }
        }

        private void DrawNumericHotizontal(int index)
        {
            int numPos = _posX + 2;
            
            ForegroundColor = ArowColor;
            SetCursorPosition(_posX, _posY);
            Write('◄');

            ForegroundColor = NumColor;
            SetCursorPosition(numPos, _posY);
            Write($"{index}{new string(' ', 1)}");

            ForegroundColor = ArowColor;
            SetCursorPosition(numPos + index.ToString().Length + 1, _posY);
            Write($"►{new string(' ', CleanSpace)}");          
        }
    }
}