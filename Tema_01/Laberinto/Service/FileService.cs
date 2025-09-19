namespace Laberinto.Service
{
    internal static class FileService
    {
        public static string[]? GetAllFiles(string directoryPath)
        {
            string[]? files = null;
            try
            {
                files = Directory.GetFiles(directoryPath);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"No tienes permiso para acceder a al directorio: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
            return files;
        }

        /// <summary>
        /// Reads a maze definition from a file and returns it as a two-dimensional character array.
        /// </summary>
        /// <param name="path">The path to the file containing the maze definition. Each line in the file represents a row of the maze, and
        /// each character in a line represents a cell.</param>
        /// <returns>A two-dimensional array of characters representing the maze, where each character corresponds to a cell in
        /// the maze. Returns <see langword="null"/> if the file cannot be read or an error occurs during processing.</returns>
        public static char[,]? GetMaze(string path)
        {
            char[,]? maze = null;
            string? line;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    List<string> lines = new List<string>();
                    while((line = sr.ReadLine()) != null) lines.Add(line.Trim());

                    byte columns = (byte)lines[0].Length;
                    maze = new char[lines.Count, columns];
                    for(byte i = 0; i < maze.GetLength(0); i++)
                    {
                        for(byte j = 0; j < maze.GetLength(1); j++)
                        {
                            maze[i, j] = lines[i][j]; //For each char of the line, this add it to an specific cord of the array.
                        }
                    }
                }
            }
            catch(OverflowException)
            {
                Console.WriteLine($"El fichero {path} contiene demsaidas líneas.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al acceder al fichero: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
            return maze;
        }
    }
}
