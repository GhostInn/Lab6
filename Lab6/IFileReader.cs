namespace Lab6;

public interface IFileReader<T>
{
    IEnumerable<T> Read(string filePath);
}
