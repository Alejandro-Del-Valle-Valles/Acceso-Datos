using Laberinto.Service;

namespace Laberinto
{
    internal class Program
    {
        static void Main(string[] args)
        {
			if (Directory.Exists(args[0])) {
                byte i = 1;
                foreach(string file in FileService.GetAllFiles(args[0]))
                {
                    Console.WriteLine($"Laberinto {i}");
                    MazeSolver ms = new MazeSolver(FileService.GetMaze(file));
                    foreach(var direction in ms.SolveMaze()) Console.WriteLine(direction);
                    i++;
                }
            }
            else Console.WriteLine($"El directorio {args[0]} no existe. Pruebe con otro directorio.");
        }

    }
}
