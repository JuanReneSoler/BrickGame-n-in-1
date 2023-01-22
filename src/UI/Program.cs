using UI;

var menu = new Menu();
menu.AddItem<SnakeGame>("Snake");
menu.AddItem<TanksGame>("Tanks");
menu.AddItem<TetrisGame>("Tetris");
menu.AddItem<TicTakToeGame>("Tic Tak Toe");
menu.AddItem<BreakoutGame>("Breakout");
menu.AddItem<LifeGame>("Game of Life");
menu.AddItem<CarsGame>("Cars");
menu.AddItem<GalagaGame>("Galaga");

var isRunning = true;
Console.CursorVisible = false;

Action _exitGame = () =>
{
    Console.CursorVisible = true;
    Console.Clear();
    isRunning = false;
};

while (isRunning)
{
    Console.Clear();
    Console.WriteLine(menu.ToString());

    var keyPress = Console.ReadKey(true);

    switch (keyPress.Key)
    {
        case ConsoleKey.UpArrow:
            menu.CursorMoveUp();
            break;
        case ConsoleKey.DownArrow:
            menu.CursorMoveDown();
            break;
        case ConsoleKey.Q:
	    _exitGame();
            break;
        case ConsoleKey.Enter:
            menu.GetItemSelected()
	    .PlayGame();
	    break;
    }
}

