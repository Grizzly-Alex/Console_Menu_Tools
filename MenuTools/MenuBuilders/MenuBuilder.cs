using static System.Console;


namespace MenuTools.MenuBuilders
{
    public sealed class MenuBuilder : ControlHandlerBuilder
    {
        private readonly int _limitUp;
        private readonly int _limitDown;
        private readonly int _step;

        public List<string> ItemsMenu { get; set; }
        public ConsoleColor PointerColor { get; set; } = ConsoleColor.White;
        public ConsoleColor ItemColor { get; set; } = ConsoleColor.White;


        public MenuBuilder(int posX, int posY, bool quitOn) : base(posX, posY, quitOn)
        {
            _limitUp = 0;
            _limitDown = 0;
            _selectedIndex = 0;
            _step = 1;
        }

        public MenuBuilder(int posX, int posY, int limitUp, int limitDown, bool quitOn) : base(posX, posY, quitOn)
        {
            _limitUp = limitUp;
            _limitDown = limitDown;
            _selectedIndex = limitUp;
            _step = 1;
        }

        public MenuBuilder(int posX, int posY, int limitUp, int limitDown, int step, bool quitOn) : base(posX, posY, quitOn)
        {
            _limitUp = limitUp;
            _limitDown = limitDown;
            _selectedIndex = limitUp;
            _step = step;
        }

        public override void ResetSelectIndex() => _selectedIndex = _limitUp;
        

        public int RunMenu()
        {
            DrawMenu();
            bool IsChose = false;
   
            int limUp = Math.Abs(_limitUp);
            int limDown = Math.Abs(_limitDown);

            while (!IsChose)
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed.Equals(ConsoleKey.UpArrow)) // move up
                {
                    _selectedIndex -= _step;

                    if (_selectedIndex < limUp)
                    {
                        _selectedIndex = ItemsMenu.Count - (1 + limDown);
                    }
                }
                else if (keyPressed.Equals(ConsoleKey.DownArrow)) //move down
                {
                    _selectedIndex += _step;

                    if (_selectedIndex >= (ItemsMenu.Count - limDown))
                    {
                        _selectedIndex = limUp;
                    }
                }
                else if (keyPressed.Equals(ConsoleKey.Escape) && _quitOn) // quit
                {
                    _selectedIndex = (-1 + limUp) / _step;
                    IsChose = true;
                }
                else if (keyPressed.Equals(ConsoleKey.Enter)) // choise
                {
                    IsChose = true;
                }
                DrawMenu();
            }

            return (_selectedIndex - limUp) / _step;
        }


        private void DrawMenu()
        {
            char pointer = ' ';

            for (int i = 0; i < ItemsMenu.Count; i++)
            {
                SetCursorPosition(_posX, _posY + i);
                ForegroundColor = ItemColor;
                if (i == _selectedIndex)
                {
                    ForegroundColor = PointerColor;
                    pointer = '►';
                }

                Write($"{pointer} {ItemsMenu[i]}");
                pointer = ' ';
                ResetColor();
            }
        }
    }
}