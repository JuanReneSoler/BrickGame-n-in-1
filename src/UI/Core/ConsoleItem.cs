namespace UI
{
    class ConsoleItem
    {
        private int _x;
        private int _y;
        public virtual int X
        {
            get => _x;
            set => _x = value;
        }
        public virtual int Y
        {
            get => _y;
            set => _y = value;
        }
        public char Template { get; set; }

        public ConsoleItem(int x, int y)
        {
            _x = x;
            _y = y;
            Template = ' ';
        }

        public override string ToString()
        {
            Console.SetCursorPosition(_x, _y);
            return Template.ToString();
        }
    }
}
