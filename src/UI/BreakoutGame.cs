namespace UI
{
    class BreakoutGame
    {
        bool _isRunning;
        int _elapsed = 200;

        List<ConsoleItem> _racket;
        ConsoleItem _ball;
        List<List<ConsoleItem>> _obstacles;

        ConsoleKey _xBallMovement;
        ConsoleKey _yBallMovement;

        public BreakoutGame()
        {
            _isRunning = true;
            var h = Console.BufferHeight - 1;
            var w = (Console.BufferWidth / 2) - 5;
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
            _ball = new ConsoleItem(w + 5, h - 1) { Template = '@' };
            _xBallMovement = ConsoleKey.RightArrow;
            _yBallMovement = ConsoleKey.UpArrow;

            _obstacles = new List<List<ConsoleItem>>
            {
               new List<ConsoleItem>
	       {
		   new ConsoleItem(6,6){ Template = '#'},
		   new ConsoleItem(7,6){ Template = '#'},
		   new ConsoleItem(8,6){ Template = '#'},
		   new ConsoleItem(9,6){ Template = '#'},
		   new ConsoleItem(10,6){ Template = '#'},
		   new ConsoleItem(11,6){ Template = '#'},
	       },
	       new List<ConsoleItem>
	       {
		   new ConsoleItem(13,6){ Template = '#'},
		   new ConsoleItem(14,6){ Template = '#'},
		   new ConsoleItem(15,6){ Template = '#'},
		   new ConsoleItem(16,6){ Template = '#'},
		   new ConsoleItem(17,6){ Template = '#'},
		   new ConsoleItem(18,6){ Template = '#'},
	       },
	       new List<ConsoleItem>
	       {
		   new ConsoleItem(20,6){ Template = '#'},
		   new ConsoleItem(21,6){ Template = '#'},
		   new ConsoleItem(22,6){ Template = '#'},
		   new ConsoleItem(23,6){ Template = '#'},
		   new ConsoleItem(24,6){ Template = '#'},
		   new ConsoleItem(25,6){ Template = '#'},
	       },
	       new List<ConsoleItem>
	       {
		   new ConsoleItem(27,6){ Template = '#'},
		   new ConsoleItem(28,6){ Template = '#'},
		   new ConsoleItem(29,6){ Template = '#'},
		   new ConsoleItem(30,6){ Template = '#'},
		   new ConsoleItem(31,6){ Template = '#'},
		   new ConsoleItem(32,6){ Template = '#'},
	       },
               new List<ConsoleItem>
	       {
		   new ConsoleItem(9,8){ Template = '#'},
		   new ConsoleItem(10,8){ Template = '#'},
		   new ConsoleItem(11,8){ Template = '#'},
		   new ConsoleItem(12,8){ Template = '#'},
		   new ConsoleItem(13,8){ Template = '#'},
		   new ConsoleItem(14,8){ Template = '#'},
	       },
	       new List<ConsoleItem>
	       {
		   new ConsoleItem(16,8){ Template = '#'},
		   new ConsoleItem(17,8){ Template = '#'},
		   new ConsoleItem(18,8){ Template = '#'},
		   new ConsoleItem(19,8){ Template = '#'},
		   new ConsoleItem(20,8){ Template = '#'},
		   new ConsoleItem(21,8){ Template = '#'},
	       },
            };
        }

        public bool Render()
        {
            Console.Clear();
            _racket.ForEach(item => Console.Write(item));
            _obstacles.ForEach(items => items.ForEach(i => Console.Write(i)));
            Console.Write(_ball);
            MoveBall();
            return _isRunning;
        }

        void MoveBall()
        {
            if (_xBallMovement == ConsoleKey.RightArrow)
                _ball.X += 1;

            if (_xBallMovement == ConsoleKey.LeftArrow)
                _ball.X -= 1;

            if (_yBallMovement == ConsoleKey.UpArrow)
                _ball.Y -= 1;

            if (_yBallMovement == ConsoleKey.DownArrow)
                _ball.Y += 1;

            if (_ball.X == Console.BufferWidth - 1)
                _xBallMovement = ConsoleKey.LeftArrow;

            if (_ball.X == 1)
                _xBallMovement = ConsoleKey.RightArrow;

            if (_ball.Y == Console.BufferHeight - 1)
                _xBallMovement = ConsoleKey.UpArrow;

            if (_ball.Y == 1)
                _yBallMovement = ConsoleKey.DownArrow;

            if (_racket.Any(i => i.Y - 1 == _ball.Y && i.X == _ball.X))
                _yBallMovement = ConsoleKey.UpArrow;

	    if(_obstacles.Any(obstacle => obstacle.Any(i => _ball.X == i.X && _ball.Y == i.Y)))
	    {
		var item = _obstacles.Find(x => x.Any(i => i.X == _ball.X && i.Y == _ball.Y));
		if(item != null) _obstacles.Remove(item);
	    }
        }

        void MoveRight() => _racket.ForEach(i => i.X += 3);

        void MoveLeft() => _racket.ForEach(i => i.X -= 3);

        public static void Init()
        {
            var breakoutGame = new BreakoutGame();

            while (breakoutGame.Render())
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Q:
                            breakoutGame._isRunning = false;
                            break;
                        case ConsoleKey.LeftArrow:
                            breakoutGame.MoveLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            breakoutGame.MoveRight();
                            break;
                    }
                }
                Thread.Sleep(breakoutGame._elapsed);
            }
        }
    }
}
