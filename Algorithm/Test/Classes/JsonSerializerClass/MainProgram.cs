using System.Text.Json;

namespace Test.Classes.JsonSerializerClass;

public class Person
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public override string ToString()
    {
        return $"Name is {FirstName} {LastName}";
    }
}

public class MainProgram
{
    static void Main()
    {
        var person = new Person { FirstName = "Chuan", LastName = "Yu" };
        Console.WriteLine($"Person: {person}");

        var jsonString = JsonSerializer.Serialize(person);
        
        Console.WriteLine(jsonString);
        
        var person2 = JsonSerializer.Deserialize(jsonString, typeof(Person));
        Console.WriteLine($"Person2: {person2}");
    }
}