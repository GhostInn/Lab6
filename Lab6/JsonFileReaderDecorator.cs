using Newtonsoft.Json;
namespace Lab6;

public class JsonFileReaderDecorator<T> : IFileReader<T>
{
    private readonly IFileReader<T> _decorated;

    public JsonFileReaderDecorator(IFileReader<T> decorated)
    {
        _decorated = decorated;
    }

    public IEnumerable<T> Read(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found.", filePath);
        }
        
        var json = File.ReadAllText(filePath);

        var objects = JsonConvert.DeserializeObject<IEnumerable<T>>(json);

        return objects;
    }
}
