using WildFarm.IO.Interfaces;

namespace _04.WildFarm.IO;

public class ConsoleReader : IReader
{
    public string ReadLine() => Console.ReadLine();
}