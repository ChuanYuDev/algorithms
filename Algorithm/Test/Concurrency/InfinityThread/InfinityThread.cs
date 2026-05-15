namespace Test.Concurrency.InfinityThread;

public class InfinityThread
{
    static void Main()
    {
        Thread thread = new Thread(() =>
        {
            int i = 0;
            
            while (i < 100)
            {
                Console.WriteLine(i);
                i++;
                Thread.Sleep(500);
            }
        });
        
        thread.Start();
        
        Console.WriteLine("Main thread exits");
    }
}