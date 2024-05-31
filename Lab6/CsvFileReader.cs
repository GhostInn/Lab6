namespace Lab6;

public class CsvFileReader<T> : IFileReader<T>
{
    private readonly Func<string[], T> _mapper;

    public CsvFileReader(Func<string[], T> mapper)
    {
        _mapper = mapper;
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

        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(',');

                yield return _mapper(values);
            }
        }
    }
}
