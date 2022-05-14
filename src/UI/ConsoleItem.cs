namespace UI
{
  class ConsoleItem
  {
    protected int _x;
    protected int _y;
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
      X = x;
      Y = y;
      Template = ' ';
    }

    public override string ToString()
    {
      Console.SetCursorPosition(X, Y);
      return Template.ToString();
    }
  }
}
