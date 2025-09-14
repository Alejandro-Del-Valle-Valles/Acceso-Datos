using T01_Ejercicios_Manejo_Ficheros.Servicios;

namespace T01_Ejercicios_Manejo_Ficheros.Apps
{
    internal class Ejercicio04App
    {

        /// <summary>
        /// Reads a file line by line, counts the total number of lines, and determines how many of them represent even
        /// numbers.
        /// </summary>
        /// <remarks>The method reads the file specified by <see cref="DirectoryService.GetFilePath"/> and
        /// processes its content. Each line is expected to contain a number or text. Lines that cannot be parsed as
        /// integers are ignored for the even number count. The results, including the total number of lines and the
        /// count of even numbers, are written to the console.</remarks>
        public static void Start()
        {
            try
            {
                using (StreamReader sr = new StreamReader(DirectoryService.GetFilePath("enteros.txt")))
                {
                    string? line = sr.ReadLine();
                    int numberOfNumbers = 0;
                    int actualNumber;
                    int numberOfPeers = 0;
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        numberOfNumbers++;
                        if(int.TryParse(line, out actualNumber))
                        {
                            if(actualNumber % 2 == 0) numberOfPeers++;
                        }
                        line = sr.ReadLine();
                    }
                    Console.WriteLine($"Hay un total de {numberOfNumbers} números.\nDe los cuales {numberOfPeers} son pares");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
