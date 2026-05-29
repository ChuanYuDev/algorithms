namespace Test.Concurrency.CancellationTokenTest;

public class ThreadWorker
{
    public void DoWork(CancellationToken ct)
    {
        SemaphoreSlim s = new SemaphoreSlim(0, 1);
        Console.WriteLine("Thread is waiting");

        try
        {
            s.Wait(ct);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation is canceled");
        }
    }
}

public class CancellationTokenCancel
{
    public static void Main()
    {
        CancellationTokenSource Cts = new CancellationTokenSource();
        CancellationToken ct = Cts.Token;

        Thread thr = new Thread(() => new ThreadWorker().DoWork(ct));
        thr.Start();

        Thread.Sleep(1000); // allow some steps to run

        Cts.Cancel();

        Console.WriteLine("Main thread exits.");
    }
    
}