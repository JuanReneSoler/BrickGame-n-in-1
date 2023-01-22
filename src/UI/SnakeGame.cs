namespace UI
{
    class SnakeGame
    {
        List<LinkedConsoleItem> _snake;
        bool _isRunning;
        ConsoleKey _pressedKey;
        int _elapsed;
        ConsoleItem _fruit;
        Random rX;
        Random rY;

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
            rX = new Random();
            rY = new Random();
            _fruit = new ConsoleItem(rX.Next(0, Console.BufferWidth), rY.Next(0, Console.BufferHeight)) { Template = '@' };
        }

        void Close() => _isRunning = false;

        bool Render()
        {
            Console.Clear();
            _snake.ForEach(x => Console.Write(x));
            Console.Write(_fruit);
            SnakeMove();
            return _isRunning;
        }

        void SnakeMove()
        {
            var lp = _snake.Count - 1;
            var head = _snake[lp];
            switch (_pressedKey)
            {
                case ConsoleKey.UpArrow: 
		    head.Y -= 1; 
		    head.Template = '^'; 
		    break;
                case ConsoleKey.DownArrow: 
		    head.Y += 1; 
		    head.Template = 'v'; 
		    break;
                case ConsoleKey.LeftArrow: 
		    head.X -= 1; 
		    head.Template = '<'; 
		    break;
                case ConsoleKey.RightArrow: 
		    head.X += 1; 
		    head.Template = '>'; 
		    break;
            }
            if (head.X == _fruit.X && head.Y == _fruit.Y)
            {
                var first = _snake[0];
                var nFirst = new LinkedConsoleItem(first.X, first.Y) 
		{ 
		    Template = '0' 
		};
                first.Previous = nFirst;
                _snake.Insert(0, nFirst);
                _fruit.X = rX.Next(0, Console.BufferWidth);
                _fruit.Y = rY.Next(0, Console.BufferHeight);
            }
        }

        void MoveUp() => _pressedKey = ConsoleKey.UpArrow;
        void MoveDown() => _pressedKey = ConsoleKey.DownArrow;
        void MoveLeft() => _pressedKey = ConsoleKey.LeftArrow;
        void MoveRight() => _pressedKey = ConsoleKey.RightArrow;

        public static void Init()
        {
            var snakeGame = new SnakeGame();

            while (snakeGame.Render())
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow: 
			    snakeGame.MoveUp(); 
			    break;
                        case ConsoleKey.DownArrow: 
			    snakeGame.MoveDown(); 
			    break;
                        case ConsoleKey.LeftArrow: 
			    snakeGame.MoveLeft(); 
			    break;
                        case ConsoleKey.RightArrow: 
			    snakeGame.MoveRight(); 
			    break;
                        case ConsoleKey.Q: 
			    snakeGame.Close(); 
			    break;
                    }
                }
                Thread.Sleep(snakeGame._elapsed);
            }
        }
    }
}
