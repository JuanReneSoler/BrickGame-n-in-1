namespace UI
{
  static class PlayerLauncher
  {
    public static void Play<TPlayer>(TPlayer game) where TPlayer : Type 
      => game.GetMethod("Init").Invoke(null, null);
  }
}
