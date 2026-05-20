namespace Leetcode.FizzBuzzMultithreaded;

public class FizzBuzz2
{
    private int n;

    private readonly SemaphoreSlim _sFizz = new (0, 1);
    private readonly SemaphoreSlim _sBuzz = new (0, 1);
    private readonly SemaphoreSlim _sFizzBuzz = new (0, 1);
    private readonly Semaphore _sNumber = new (0, 1);
    private readonly CancellationTokenSource _cts = new();

    public FizzBuzz2(int n)
    {
        this.n = n;
    }

    // printFizz() outputs "fizz".
    public void Fizz(Action printFizz)
    {
        Worker(_sFizz, printFizz);
    }

    // printBuzz() outputs "buzz".
    public void Buzz(Action printBuzz)
    {
        Worker(_sBuzz, printBuzz);
    }

    // printFizzBuzz() outputs "fizzbuzz".
    public void Fizzbuzz(Action printFizzBuzz)
    {
        Worker(_sFizzBuzz, printFizzBuzz);
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Number(Action<int> printNumber)
    {
        int i = 0;
        
        while (i <= n - 1)
        {
            i++;
            
            if (i % 3 == 0 && i % 5 == 0)
            {
                _sFizzBuzz.Release();
            }
            else if (i % 3 == 0)
            {
                _sFizz.Release();
            }
            else if (i % 5 == 0)
            {
                _sBuzz.Release();
            }
            else
            {
                printNumber(i);
                continue;
            }

            _sNumber.WaitOne();
        }
        
        _cts.Cancel();
        _cts.Dispose();
    }

    private void Worker(SemaphoreSlim semaphore, Action fuc)
    {
        try
        {
            while (true)
            {
                semaphore.Wait(_cts.Token);
                fuc();
                _sNumber.Release();
            }
            
        }
        catch(OperationCanceledException)
        {}
    }
}

