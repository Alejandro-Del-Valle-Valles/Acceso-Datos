using T01_Ejercicios_Manejo_Ficheros.Servicios;

namespace T01_Ejercicios_Manejo_Ficheros.Apps
{
    internal class Ejercicio03App
    {
        private const int MIN_NUMBER = 1;
        private const int MAX_NUMBER = 100;

        public static void Start()
        {
            int numberOfNumbersToAsk = ESHelper.Teclado.LeerEntero(1, int.MaxValue);
            int[] numbers = new int[numberOfNumbersToAsk];
            for (int i = 0; i < numberOfNumbersToAsk; i++) numbers[i] = ESHelper.Teclado.LeerEntero(MIN_NUMBER, MAX_NUMBER);
            SaveData(numbers);
        }

        /// <summary>
        /// Saves an array of integers to a text file, appending the values to the file if it already exists.
        /// </summary>
        /// <param name="numbers">An array of integers to be written to the file. Each integer is written on a new line.</param>
        private static void SaveData(int[] numbers)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(DirectoryService.GetFilePath("enteros.txt"), true))
                {
                    foreach (int number in numbers)
                    {
                        sw.WriteLine(number);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
