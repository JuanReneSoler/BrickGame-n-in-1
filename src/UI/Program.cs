using UI;

var menu = new Menu();
var isRunning = true;
Console.CursorVisible = false;

while(isRunning)
{
  Console.Clear();
  Console.WriteLine(menu.ToString());

  var keyPress = Console.ReadKey(true);

  switch(keyPress.Key)
  {
    case ConsoleKey.UpArrow: menu.CursorMoveUp(); break;
    case ConsoleKey.DownArrow: menu.CursorMoveDown(); break;
    case ConsoleKey.Q: 
      Console.CursorVisible = true; 
      Console.Clear();
      isRunning = false;
      break;
    case ConsoleKey.Enter: PlayerLauncher.Play(menu.GetItemSelected()); break;
  }
}

