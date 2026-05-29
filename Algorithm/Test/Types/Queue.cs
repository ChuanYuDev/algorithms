namespace Test.Types;

public class Queue
{
    static void Main()
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);

        foreach (var i in q)
        {
            Console.WriteLine(i);
        }
    }
}