using System.Globalization;
namespace Lab6;

public static class Program
{
    public static void Main()
    {
        var csvReader = new CsvFileReader<Person>(values => new Person
        {
            Name = values[0],
            Age = int.Parse(values[1], CultureInfo.InvariantCulture)
        });

        var jsonReader = new JsonFileReaderDecorator<Person>(csvReader);

        foreach (var person in jsonReader.Read("persons.json"))
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}
