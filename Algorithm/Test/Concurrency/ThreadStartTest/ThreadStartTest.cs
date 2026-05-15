namespace Test.Concurrency.ThreadStartTest;

class ThreadStartTest
{
    static void Main() 
    {
        Thread newThread = new Thread(new ThreadStart(Work.DoWork));
        newThread.Start();
    }
}

class Work 
{
    Work() {}

    public static void DoWork()
    {
        Console.WriteLine("Work in thread");
    }
}