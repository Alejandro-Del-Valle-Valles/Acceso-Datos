using AdivinaElNumero.Model;
using AdivinaElNumero.Interfaces;
using Newtonsoft.Json;

namespace AdivinaElNumero.Exercises
{
    internal class Exercise17App : IConfiguration
    {
        private static readonly string _path = "../../../Files/NumberConfiguration.json";
        private static readonly JsonSerializerSettings _jsettings = new()
        {
            DateFormatString = "dd-MM-yyyy"
        };
        private static Random rn = new();
        public Configuration? GetConfiguration() => JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(_path), _jsettings);

        public void Start()
        {
            Configuration? config = GetConfiguration();
            if (config != null && DateTime.Now <= config.MaxDate)
            {
                int minimu = config?.Minimun ?? 0;
                int maximun = config?.Maximun ?? 1;
                int numberToGuess = rn.Next(minimu, maximun + 1);
                int userNumber;
                do
                {
                    userNumber = AskNumber();
                    if (userNumber < numberToGuess) Console.WriteLine("El numero que has introducido es MENOR que el que debes adivinar.");
                    else if (userNumber > numberToGuess) Console.WriteLine("El numero que has introducido es MAYOR que el que debes adivinar.");
                } while (userNumber != numberToGuess);
                Console.WriteLine(config?.RightMessage ?? "¡Has ganado!");
            }
            else Console.WriteLine("La fecha límte para jugar ha concluido ya.");
        }

        private int AskNumber()
        {
            Configuration? config = GetConfiguration();
            int userNumber;
            bool isValid = false;
            do
            {
                Console.WriteLine($"Introduce un número entre {config?.Minimun} y {config?.Maximun}:");
                isValid = int.TryParse(Console.ReadLine(), out userNumber);
                if (!isValid || userNumber > config?.Maximun || userNumber < config?.Minimun)
                {
                    Console.WriteLine("Debes introducir un número dentro del rango especificado.");
                    isValid = false;
                }
            } while (!isValid);
            return userNumber;
        }
    }
}
