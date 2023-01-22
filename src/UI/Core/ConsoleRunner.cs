namespace UI
{
    class ConsoleRunner
    {
	Type _type;

        public ConsoleRunner(Type type)
        {
            _type = type;
        }

        public void PlayGame() =>
	    _type.GetMethod("Init")?
	    .Invoke(null, null);
    }
}
