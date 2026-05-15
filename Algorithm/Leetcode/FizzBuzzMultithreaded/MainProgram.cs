using System.Threading;

namespace Leetcode.FizzBuzzMultithreaded;

//  You have the four functions:
//      printFizz that prints the word "fizz" to the console,
//      printBuzz that prints the word "buzz" to the console,
//      printFizzBuzz that prints the word "fizzbuzz" to the console, and
//      printNumber that prints a given integer to the console.
//
//  You are given an instance of the class FizzBuzz that has four functions: fizz, buzz, fizzbuzz and number.
//  The same instance of FizzBuzz will be passed to four different threads:
//      Thread A: calls fizz() that should output the word "fizz".
//      Thread B: calls buzz() that should output the word "buzz".
//      Thread C: calls fizzbuzz() that should output the word "fizzbuzz".
//      Thread D: calls number() that should only output the integers.

//  Modify the given class to output the series [1, 2, "fizz", 4, "buzz", ...] where the ith token (1-indexed) of the series is:
//      "fizzbuzz" if i is divisible by 3 and 5,
//      "fizz" if i is divisible by 3 and not 5,
//      "buzz" if i is divisible by 5 and not 3, or
//      i if i is not divisible by 3 or 5.
//
//  Implement the FizzBuzz class:
//      FizzBuzz(int n) Initializes the object with the number n that represents the length of the sequence that should be printed.
//      void fizz(printFizz) Calls printFizz to output "fizz".
//      void buzz(printBuzz) Calls printBuzz to output "buzz".
//      void fizzbuzz(printFizzBuzz) Calls printFizzBuzz to output "fizzbuzz".
//      void number(printNumber) Calls printNumber to output the numbers.

//  i % 3 == 0 && i % 5 != 0
//      fizz, Thread A

//  i % 3 != 0 && i % 5 == 0
//      buzz, Thread B

//  i % 3 == 0 && i % 5 == 0
//      fizzbuzz, Thread C

//  i % 3 != 0 && i % 5 != 0
//      i, Thread D

//  Thread x need semaphore x, i <= n

//  How to terminate Thread i <= n is not working
//  How to Control

public class MainProgram
{
    static void Main()
    {
        int n = 15;
        
        Console.WriteLine($"n: {n}");
        TestFizzBuzz(n);
        //  Output: [1,2,"fizz",4,"buzz","fizz",7,8,"fizz","buzz",11,"fizz",13,14,"fizzbuzz"]
        
        // Thread.Sleep(500);

        // n = 5;
        // Console.WriteLine($"n: {n}");
        // TestFizzBuzz(n);
        //  Output: [1,2,"fizz",4,"buzz"]
    }
    
    private static void TestFizzBuzz(int n)
    {
        var fizzBuzz = new FizzBuzz2(n);
        
        // Thread A: calls fizz() that should output the word "fizz".
        Thread threadA = new Thread(() =>
        {
            fizzBuzz.Fizz(PrintFizz);
        });
        
        // Thread B: calls buzz() that should output the word "buzz".
        Thread threadB = new Thread(() =>
        {
            fizzBuzz.Buzz(PrintBuzz);
        });
        
        // Thread C: calls fizzbuzz() that should output the word "fizzbuzz".
        Thread threadC = new Thread(() =>
        {
            fizzBuzz.Fizzbuzz(PrintFizzBuzz);
        });
        
        // Thread D: calls number() that should only output the integers.
        Thread threadD = new Thread(() =>
        {
            fizzBuzz.Number(PrintNumber);
        });
        
        threadA.Start();
        threadB.Start();
        threadC.Start();
        threadD.Start();
    }
    
    private static void PrintFizz()
    {
        Console.WriteLine("fizz");
    }

    private static void PrintBuzz()
    {
        Console.WriteLine("buzz");
    }

    private static void PrintFizzBuzz()
    {
        Console.WriteLine("fizzbuzz");
    }

    private static void PrintNumber(int n)
    {
        Console.WriteLine(n);
    }
}