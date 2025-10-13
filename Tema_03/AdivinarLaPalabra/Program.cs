using AdivinarLaPalabra.Model;
using AdivinarLaPalabra.Services;

namespace AdivinarLaPalabra
{
    internal class Program
    {
        private static readonly JsonService jService = new();
        private static readonly Configuration? config = jService.GetConfiguration();
        private static Random rn = new();
        static void Main(string[] args)
        {
            try
            {
                Game();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void Game()
        {
            int attempts = config?.MaximunAttempts ?? 11;
            string name = AskString("Ingresa tu nombre: ");
            string? randomWordToGuess = config?.Words[rn.Next(0, config.Words.Length + 1)].ToLower();

            if (randomWordToGuess != null)
            {
                string inputWord;
                bool isCorrect = false;
                DateTime timeGameStart = DateTime.Now;
                do
                {
                    PrintWords();
                    Console.WriteLine($"Te quedan {attempts} intentos.");
                    inputWord = AskString("Introduce la palabra: ", true);
                    attempts--;
                    if(inputWord == randomWordToGuess) isCorrect = true;
                    Console.Clear();
                } while (!isCorrect && attempts > 0);

                DateTime timeGameEnd = DateTime.Now;
                TimeSpan totalTime = timeGameEnd - timeGameStart;

                if(isCorrect)
                {
                    Console.WriteLine("¡Has acertado la palabra!");
                    jService.SaveWinner(new Player(name, totalTime, config.MaximunAttempts - attempts, randomWordToGuess));
                }
                Console.WriteLine($"La duración de la partida ha sido de {totalTime}");
            }
            else Console.WriteLine(@"Ha ocurrido un error y no se puede jugar al juego.
Comprueba que el fichero de configuración está correctamente estructurado y que existen palabras para elegir.");
        }

        private static void PrintWords()
        {
            int wordsForNextLine = 0;
            foreach (string word in config.Words)
            {
                Console.Write($"{word} ");
                wordsForNextLine++;
                if (wordsForNextLine >= 5) Console.WriteLine();
            }
        }

        private static string AskString(string question, bool normalize = false)
        {
            string? input;
            do
            {
                Console.WriteLine(question);
                input = Console.ReadLine()?.Trim();
                if (normalize) input = input?.ToLower();
                if(input == null || input == "") Console.WriteLine("Debes introducir un valor diferente de vacío o solo espacios");
            } while (input == null || input == "");
            return input;
        }
    }
}
