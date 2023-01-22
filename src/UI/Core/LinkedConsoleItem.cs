namespace UI
{
    class LinkedConsoleItem : ConsoleItem
    {
        public override int X
        {
            set
            {
                if (Previous != null && value != X)
                {
                    Previous.X = X;
                    Previous.Y = Y;
                }
                base.X = value;
            }
        }

        public override int Y
        {
            set
            {
                if (Previous != null && value != Y)
                {
                    Previous.X = X;
                    Previous.Y = Y;
                }
                base.Y = value;
            }
        }

        public LinkedConsoleItem? Previous { get; set; }
        public LinkedConsoleItem(int x, int y) : base(x, y) { }
    }
}
