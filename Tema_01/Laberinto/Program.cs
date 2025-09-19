namespace Laberinto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists(args[0])) { }
            else Console.WriteLine($"El directorio {args[0]} no existe. Pruebe con otro directorio.");
        }

    }
}
