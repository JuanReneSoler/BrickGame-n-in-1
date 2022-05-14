namespace UI
{
  class Menu
  {
    int _cursorPosition;

    List<Type> items = new List<Type>
    {
      typeof(SnakeGame),
      typeof(TanksGame),
      typeof(TetrisGame),
      typeof(TicTakToeGame),
      typeof(BreakoutGame),
      typeof(LifeGame),
      typeof(CarsGame),
    };

    public Menu()
    {
      _cursorPosition = 0;
    }

    string Cursor(int position) => _cursorPosition == position ? "=>" : "  ";

    public override string ToString() => $@"
      WELCOME TO BRICKGAME N IN 1

      SELECT THE NEXT GAMES TO PLAY
	  {Cursor(0)} SNAKE
	  {Cursor(1)} TANKS
	  {Cursor(2)} TETRIS
	  {Cursor(3)} TIC TAC TOE
	  {Cursor(4)} BREAKOUT
	  {Cursor(5)} GAME OF LIFE
	  {Cursor(6)} CARS
	  PRESS Q TO QUIT";

    public void CursorMoveUp()
    {
      if(_cursorPosition > 0)
	_cursorPosition--;
    }

    public void CursorMoveDown()
    {
      if(_cursorPosition < 6)
	_cursorPosition++;
    }

    public Type GetItemSelected() => items[_cursorPosition];
  }
}
