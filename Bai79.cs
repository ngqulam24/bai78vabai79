using System;

class Program
{
    static void Main(string[] args)
    {
        // Create and start a new thread
        Thread workerThread = new Thread(DoWork);
        workerThread.Start();

        // Wait for the worker thread to finish
        workerThread.Join();

        Console.WriteLine("Main thread finished.");
    }

    static void DoWork()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Worker thread: " + i);
            Thread.Sleep(100); // Pause the worker thread for 100ms
        }
    }
}