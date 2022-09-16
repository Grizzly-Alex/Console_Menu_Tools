using static System.Console;


namespace MenuTools.MenuBuilders
{
    internal class TextericBuilder : ControlHandlerBuilder
    {
        public List<string> ItemsText { get; set; }
        private int CleanSpace => ItemsText.Select(x => x.Length).Max();

        public TextericBuilder(int posX, int posY, bool quitOn) : base(posX, posY, quitOn)
        {
        }

        public ConsoleColor TextColor { get; set; } = ConsoleColor.White;
        public ConsoleColor ArowColor { get; set; } = ConsoleColor.White;
        public override void ResetSelectIndex() => _selectedIndex = 0;

        public int RunTexteric(Mod mod)
        {
            bool IsChose = false;
            ResetSelectIndex();

            switch (mod)
            {
                case Mod.Vertical: DrawTextericVertical(_selectedIndex); break;
                case Mod.Horizontal: DrawTextericHotizontal(_selectedIndex); break;
            }

            while (!IsChose)
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed.Equals(mod.Equals(Mod.Horizontal) ? ConsoleKey.RightArrow : ConsoleKey.UpArrow))
                {
                    _selectedIndex++;

                    if (_selectedIndex == ItemsText.Count)
                    {
                        _selectedIndex = 0;
                    }

                }
                else if (keyPressed.Equals(mod.Equals(Mod.Horizontal) ? ConsoleKey.LeftArrow : ConsoleKey.DownArrow))
                {
                    _selectedIndex--;

                    if (_selectedIndex < 0)
                    {
                        _selectedIndex = ItemsText.Count - 1;
                    }
                }
                else if (keyPressed.Equals(ConsoleKey.Escape) && _quitOn) // quit
                {
                    _selectedIndex = -1;
                    IsChose = true;
                }
                else if (keyPressed.Equals(ConsoleKey.Enter)) // choise
                {
                    IsChose = true;
                }

                if (_selectedIndex >= 0)
                {
                    switch (mod)
                    {
                        case Mod.Vertical: DrawTextericVertical(_selectedIndex); break;
                        case Mod.Horizontal: DrawTextericHotizontal(_selectedIndex); break;
                    }
                }
            }
            ResetColor();

            return _selectedIndex;
        }

        private void DrawTextericVertical(int index)
        {

            for (int i = 0; i < 3; i++)
            {
                SetCursorPosition(_posX, _posY + i);
                switch (i)
                {
                    case 0: ForegroundColor = ArowColor; Write('▲'); break;
                    case 1: ForegroundColor = TextColor; Write($"{ItemsText[index]}{new string(' ', CleanSpace)}"); break;
                    case 2: ForegroundColor = ArowColor; Write('▼'); break;
                }
            }
        }

        private void DrawTextericHotizontal(int index)
        {
            int TextPos = _posX + 2;

            ForegroundColor = ArowColor;
            SetCursorPosition(_posX, _posY);
            Write('◄');

            ForegroundColor = TextColor;
            SetCursorPosition(TextPos, _posY);
            Write($"{ItemsText[index]}{new string(' ', 1)}");

            ForegroundColor = ArowColor;
            SetCursorPosition(TextPos + ItemsText[index].Length + 1, _posY);
            Write($"►{new string(' ', CleanSpace)}");
        }
    }   
}
