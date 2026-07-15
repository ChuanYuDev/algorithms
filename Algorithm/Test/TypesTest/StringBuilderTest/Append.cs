using System.Text;

namespace Test.Types.StringBuilderTest;

public class Append
{
    static void Main()
    {
        var sb = new StringBuilder("abc");
        sb.Append(sb);
        
        Console.WriteLine(sb);

    }
}