class Program
{
    static void Main()
    {
        var stopwatch = new Stopwatch();
        
        // Subscribe to events
        stopwatch.OnStarted += message => Console.WriteLine(message);
        stopwatch.OnStopped += message => Console.WriteLine(message);
        stopwatch.OnReset += message => Console.WriteLine(message);

        Console.WriteLine("Press S to start, T to stop, R to reset. Press any other key to exit.");

        while (true)
        {
            var key = Console.ReadKey(true).Key;

            switch (key) // choose the action based on the input
            {
                case ConsoleKey.S:
                    stopwatch.Start();
                    break;
                case ConsoleKey.T:
                    stopwatch.Stop();
                    break;
                case ConsoleKey.R:
                    stopwatch.Reset();
                    break;
                default:
                    stopwatch.Stop();
                    return; // Exit the application
            }
        }
    }
}