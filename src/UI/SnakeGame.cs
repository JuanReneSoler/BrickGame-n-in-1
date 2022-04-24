namespace UI
{
  class SnakeGame
  {
    List<ConsoleItem> _snake;
    ConsoleItem _fruit;
    int _puntaje;
    int _elapse;
    MovementDireccion _direction;

    SnakeGame()
    {
      _snake = new List<ConsoleItem>
      {
	new ConsoleItem{ X = 10, Y = 10, Template = '0'},
	new ConsoleItem{ X = 11, Y = 10, Template = '0'},
	new ConsoleItem{ X = 12, Y = 10, Template = '0'},
	new ConsoleItem{ X = 13, Y = 10, Template = '>'}
      };

      _fruit = new ConsoleItem{ X = 0, Y = 0, Template = '@' };

      _puntaje = 0;
      _elapse = 100;
      _direction = MovementDireccion.Right;
    }

    void SnakeMove()
    {
      _snake.ForEach(i => 
	  {
	    switch(_direction)
	    {
	      case MovementDireccion.Up: i.Y--; break;
	      case MovementDireccion.Down: i.Y++; break;
	      case MovementDireccion.Left: i.X--; break;
	      case MovementDireccion.Right: i.X++; break;
	    }
	  });
      Thread.Sleep(_elapse);
    }

    void MoveUp() => _direction = MovementDireccion.Up;
    void MoveDown() => _direction = MovementDireccion.Down;
    void MoveLeft() => _direction = MovementDireccion.Left;
    void MoveRight() => _direction = MovementDireccion.Right;

    public static void Init()
    {
      var snakeGame = new SnakeGame();
      var isRunning = true;

      while(isRunning)
      {
  	Console.Clear();
	Console.Write(string.Join(string.Empty, snakeGame._snake));
	Console.Write(snakeGame._fruit);
	snakeGame.SnakeMove();
	if(Console.KeyAvailable)
	{
	  var keyPress = Console.ReadKey(true);

	  switch(keyPress.Key)
	  {
	    case ConsoleKey.UpArrow: snakeGame.MoveUp(); break;
	    case ConsoleKey.DownArrow: snakeGame.MoveDown(); break;
	    case ConsoleKey.LeftArrow: snakeGame.MoveLeft(); break;
	    case ConsoleKey.RightArrow: snakeGame.MoveRight(); break;
	    case ConsoleKey.Q: isRunning = false; break;
	  }
	}
      }
    }
  }
}
