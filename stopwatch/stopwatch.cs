public class Stopwatch
{
    private TimeSpan timeElapsed;
    private bool isRunning;
    private Thread tickThread;

    public delegate void StopwatchEventHandler(string message);
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    public TimeSpan TimeElapsed => timeElapsed;
    public bool IsRunning => isRunning;

    public void Start() // starts from new or continue after stop
    {
        if (!isRunning)
        {
            isRunning = true;
            tickThread = new Thread(Tick);
            tickThread.Start();
            OnStarted?.Invoke("Stopwatch Started!");
        }
    }
     
    public void Stop() //stops the stopwatch
    {
        if (isRunning)
        {
            isRunning = false;
            tickThread.Join(); 
            OnStopped?.Invoke("Stopwatch Stopped!");
        }
    }

    public void Reset() //resets the counter after stopping it
    {
        Stop();
        timeElapsed = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reset!");
    }

    private void Tick()
    {
        while (isRunning)
        {
            Thread.Sleep(1000); // Wait for 1 second
            timeElapsed = timeElapsed.Add(TimeSpan.FromSeconds(1));
            Console.WriteLine($"Time Elapsed: {timeElapsed}");
        }
    }
}