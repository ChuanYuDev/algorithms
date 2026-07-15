namespace Test.Types.String;

public class Foreach
{
    static void Main()
    {
        string s = "abcdefg";

        foreach (var c in s)
        {
            Console.WriteLine(c);
        }
    }
}