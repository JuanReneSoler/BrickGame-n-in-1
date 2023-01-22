namespace UI
{
    class Menu
    {
        int _cursorPosition;
        IDictionary<String, Type> _items;

        public Menu()
        {
            _cursorPosition = 0;
            _items = new Dictionary<String, Type>();
        }

        string Cursor(int position) => _cursorPosition == position ? "=>" : "  ";

        public void AddItem<T>(String text) => _items.Add(text, typeof(T));

        String RenderItems()
        {
            var result = string.Empty;

            for (var i = 0; i < _items.Count(); i++)
                result += $"       {Cursor(i)} {GetKey(i)}\n";

            return result;
        }


        public override string ToString() => $@"
      WELCOME TO BRICKGAME N IN 1

      SELECT THE NEXT GAMES TO PLAY

{RenderItems()}
	  OR PRESS Q TO QUIT";

        public void CursorMoveUp()
        {
            if (_cursorPosition > 0)
                _cursorPosition--;
        }

        public void CursorMoveDown()
        {
            if (_cursorPosition < _items.Count() - 1)
                _cursorPosition++;
        }

        public ConsoleRunner GetItemSelected()
        {
	    var result = _items.ElementAt(_cursorPosition).Value;
	    return new ConsoleRunner(result);
            
        }

        string GetKey(int position) => _items.ElementAt(position).Key;
    }
}
