namespace UI
{
  class BreakoutGame
  {
    bool _isRunning;
    int _elapsed = 200;//800;
    List<ConsoleItem> _racket;
    ConsoleItem _ball;
    ConsoleKey _xBallMovement;
    ConsoleKey _yBallMovement;
    
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
      _ball = new ConsoleItem(w+5, h-1){ Template = '@'};
      _xBallMovement = ConsoleKey.RightArrow;
      _yBallMovement = ConsoleKey.UpArrow;
    }

    public bool Render()
    {
      Console.Clear();
      _racket.ForEach(item => Console.Write(item));
      Console.Write(_ball);
      MoveBall();
      return _isRunning;
    }

    void MoveBall()
    {
      if(_xBallMovement == ConsoleKey.RightArrow)
	_ball.X += 2;
      if(_xBallMovement == ConsoleKey.LeftArrow)
	_ball.X -= 2;
      if(_yBallMovement == ConsoleKey.UpArrow)
	_ball.Y -= 1;
      if(_yBallMovement == ConsoleKey.DownArrow)
	_ball.Y += 1;
      if(_ball.X == Console.BufferWidth - 1)
	_xBallMovement = ConsoleKey.LeftArrow;
      if(_ball.X == 1)
	_xBallMovement = ConsoleKey.RightArrow;
      /*if(_ball.Y == Console.BufferHeight - 1)
	yMovement = ConsoleKey.UpArrow;*/
      if(_racket.Any(i => i.Y - 1 == _ball.Y && i.X == _ball.X))
	_yBallMovement = ConsoleKey.UpArrow;
      if(_ball.Y == 1)
	_yBallMovement = ConsoleKey.DownArrow;
    }

    void MoveRight()
    {
      _racket.ForEach(i => i.X += 3);
    }

    void MoveLeft()
    {
      _racket.ForEach(i => i.X -= 3);
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
	    case ConsoleKey.LeftArrow: breakoutGame.MoveLeft(); break;
	    case ConsoleKey.RightArrow: breakoutGame.MoveRight(); break;
	  }
	}
	Thread.Sleep(breakoutGame._elapsed);
      }
    }
  }
}
