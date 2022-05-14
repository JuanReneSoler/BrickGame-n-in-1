namespace UI
{
  class LinkedConsoleItem : ConsoleItem
  {
    public override int X
    {
      set
      {
	if(Previous != null && value != X)
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
	if(Previous != null && value != Y)
	{
	  Previous.X = X;
	  Previous.Y = Y;
	}
	base.Y = value;
      }
    }

    public LinkedConsoleItem? Previous { get; set; }
    public LinkedConsoleItem(int x, int y) : base(x, y){}
  }

  class SnakeGame
  {
    List<LinkedConsoleItem> _snake;
    bool _isRunning;
    ConsoleKey _pressedKey;
    int _elapsed;

    SnakeGame()
    {
      _snake = new List<LinkedConsoleItem>
      {
	new LinkedConsoleItem(10, 10){ Template = '0' },
	new LinkedConsoleItem(11, 10){ Template = '0' },
	new LinkedConsoleItem(12, 10){ Template = '0' },
	new LinkedConsoleItem(13, 10){ Template = '>' }
      };

      _snake[3].Previous = _snake[2];
      _snake[2].Previous = _snake[1];
      _snake[1].Previous = _snake[0];

      _pressedKey = ConsoleKey.RightArrow;
      _isRunning = true;
      _elapsed = 200;
    }

    void Close() => _isRunning = false;

    bool Render()
    {
      Console.Clear();
      _snake.ForEach(x => Console.Write(x.ToString()));
      SnakeMove();
      return _isRunning;
    }

    void SnakeMove()
    {
      var lp = _snake.Count - 1;
      switch(_pressedKey)
      {
	case ConsoleKey.UpArrow: _snake[lp].Y -= 1; _snake[lp].Template = '^'; break;
	case ConsoleKey.DownArrow: _snake[lp].Y += 1; _snake[lp].Template = 'v'; break;
	case ConsoleKey.LeftArrow: _snake[lp].X -= 1; _snake[lp].Template = '<'; break;
	case ConsoleKey.RightArrow: _snake[lp].X += 1; _snake[lp].Template = '>'; break;
      }
    }

    void MoveUp() => _pressedKey = ConsoleKey.UpArrow;
    void MoveDown() => _pressedKey = ConsoleKey.DownArrow;
    void MoveLeft() => _pressedKey = ConsoleKey.LeftArrow;
    void MoveRight() => _pressedKey = ConsoleKey.RightArrow;

    public static void Init()
    {
      var snakeGame = new SnakeGame();

      while(snakeGame.Render())
      {
	if(Console.KeyAvailable)
	{
	  switch(Console.ReadKey(true).Key)
	  {
	    case ConsoleKey.UpArrow: snakeGame.MoveUp(); break;
	    case ConsoleKey.DownArrow: snakeGame.MoveDown(); break;
	    case ConsoleKey.LeftArrow: snakeGame.MoveLeft(); break;
	    case ConsoleKey.RightArrow: snakeGame.MoveRight(); break;
	    case ConsoleKey.Q: snakeGame.Close(); break;
	  }
	}
      	Thread.Sleep(snakeGame._elapsed);
      }
    }
  }
}
