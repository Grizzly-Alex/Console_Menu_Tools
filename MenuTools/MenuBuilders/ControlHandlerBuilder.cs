using static System.Console;


namespace MenuTools.MenuBuilders
{
    public abstract class ControlHandlerBuilder
    {
        protected int _selectedIndex;
        protected bool _quitOn;

        protected int _posX;
        protected int _posY;

        protected ControlHandlerBuilder(int posX, int posY, bool quitOn)
        {
            _posX = posX;
            _posY = posY;
            _quitOn = quitOn;
        }

        public abstract void ResetSelectIndex();

        public void SetCursorVisible(bool visible) => CursorVisible = visible;

        protected void SetPosition(int posX, int posY)
        {
            CursorLeft = Math.Abs(posX);
            CursorTop = Math.Abs(posY);
        }
    }
}