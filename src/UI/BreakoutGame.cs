namespace UI
{
  class BreakoutGame
  {
    bool _isRunning;
    int _elapsed = 200;
    List<ConsoleItem> _racket;
    ConsoleItem ball;
    
    public BreakoutGame()
    {
      _isRunning = true;
      var h = Console.BufferHeight - 1;
      var w = (Console.BufferWidth/2)-5;
      _racket = new List<ConsoleItem>
      {
	new ConsoleItem(w, h){ Template = '#' },
	new ConsoleItem(w+1, h){ Template = '#' },
	new ConsoleItem(w+2, h){ Template = '#' },
	new ConsoleItem(w+3, h){ Template = '#' },
	new ConsoleItem(w+4, h){ Template = '#' },
	new ConsoleItem(w+5, h){ Template = '#' },
	new ConsoleItem(w+6, h){ Template = '#' },
	new ConsoleItem(w+7, h){ Template = '#' },
	new ConsoleItem(w+8, h){ Template = '#' },
	new ConsoleItem(w+9, h){ Template = '#' },
	new ConsoleItem(w+10, h){ Template = '#' },
      };
      ball = new ConsoleItem(w+5, h-1){ Template = '@'};
    }

    public bool Render()
    {
      Console.Clear();
      _racket.ForEach(item => Console.Write(item));
      Console.Write(ball);
      return _isRunning;
    }

    public static void Init()
    {
      var breakoutGame = new BreakoutGame();
      
      while(breakoutGame.Render())
      {
	if(Console.KeyAvailable)
	{
	  switch(Console.ReadKey(true).Key)
	  {
	    case ConsoleKey.Q: breakoutGame._isRunning = false; break;
	  }
	}
	Thread.Sleep(breakoutGame._elapsed);
      }
    }
  }
}
