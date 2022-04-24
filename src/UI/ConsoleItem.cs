namespace UI
{
  class ConsoleItem
  {
    public int X { get; set; }
    public int Y { get; set; }
    public char Template { get; set; }

    public override string ToString()
    {
      Console.SetCursorPosition(X, Y);
      return Template.ToString();
    }
  }
}
