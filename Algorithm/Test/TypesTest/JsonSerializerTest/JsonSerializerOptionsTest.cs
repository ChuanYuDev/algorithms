using System.Text.Json;

namespace Test.TypesTest.JsonSerializerTest;

public class JsonSerializerOptionsTest
{
    public static void Main()
    {
        string jsonString = """{ "firstName": "Chuan", "lastName": "Yu" }""";
    
        Console.WriteLine($"Person: {jsonString}");

        var person1 = JsonSerializer.Deserialize<Person>(jsonString);
        Console.WriteLine($"Person1: {person1}");
        
        var person2 = JsonSerializer.Deserialize<Person>(jsonString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        Console.WriteLine($"Person2: {person2}");
    }
}