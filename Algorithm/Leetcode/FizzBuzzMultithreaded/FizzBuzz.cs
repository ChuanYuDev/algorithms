namespace Leetcode.FizzBuzzMultithreaded;

public class FizzBuzz
{
    private int n;

    private readonly Semaphore _sFizz = new Semaphore(0, 1);
    private readonly Semaphore _sBuzz = new Semaphore(0, 1);
    private readonly Semaphore _sFizzBuzz = new Semaphore(0, 1);
    private readonly Semaphore _sNumber = new Semaphore(0, 1);

    public FizzBuzz(int n)
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
    }

    private void Worker(Semaphore semaphore, Action fuc)
    {
        Thread.CurrentThread.IsBackground = true;
        
        while (semaphore.WaitOne())
        {
            fuc();
            _sNumber.Release();
        }
    }
}

