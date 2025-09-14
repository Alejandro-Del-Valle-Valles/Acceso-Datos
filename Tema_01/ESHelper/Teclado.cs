

namespace ESHelper
{
    public class Teclado
    {
        /// <summary>
        /// Reads a non-empty, non-whitespace string from the console.
        /// </summary>
        /// <remarks>This method repeatedly prompts the user until a valid input is provided.  An input is
        /// considered valid if it is not null, empty, or consists only of whitespace characters.</remarks>
        /// <returns>The string entered by the user, guaranteed to be non-empty and non-whitespace.</returns>
        public static string LeerTexto()
        {
            string input;
            do
            {
                Console.WriteLine("Introduce un texto:");
            } while(string.IsNullOrWhiteSpace(input = Console.ReadLine() ?? string.Empty));
            return input;
        }

        /// <summary>
        /// Reads an integer from the console within a specified range, inclusive of the minimum and maximum values.
        /// </summary>
        /// <remarks>The method repeatedly prompts the user until a valid integer within the specified
        /// range is entered. If the input is not a valid integer, the user is informed and prompted again.</remarks>
        /// <param name="min">The minimum allowable value for the input.</param>
        /// <param name="max">The maximum allowable value for the input.</param>
        /// <returns>The integer entered by the user that falls within the specified range.</returns>
        public static int LeerEntero(int min, int max)
        {
            int input;
            bool isInt;
            do
            {
                Console.WriteLine($"Introduce un número entero entre {min} y {max}. Ambos inclusive:");
                isInt = int.TryParse( Console.ReadLine(), out input );
                if (!isInt) Console.WriteLine("Debe introducir un número entero.");
            } while (!isInt && (input < min || input > max));
            return input;
        }

        /// <summary>
        /// Reads a decimal number from the console within the specified range, inclusive.
        /// </summary>
        /// <remarks>The method repeatedly prompts the user to enter a valid decimal number until the
        /// input is both a valid decimal  and within the specified range. If the input is invalid, an error message is
        /// displayed, and the user is prompted again.</remarks>
        /// <param name="min">The minimum allowable value for the input, inclusive.</param>
        /// <param name="max">The maximum allowable value for the input, inclusive.</param>
        /// <returns>The decimal number entered by the user that falls within the specified range.</returns>
        public static decimal LeerDecimal(decimal min, decimal max)
        {
            decimal input;
            bool isDecimal;
            do
            {
                Console.WriteLine($"Introduzca un numero con decimal entre {min} y {max}. Ambos inclusive:");
                isDecimal = decimal.TryParse( Console.ReadLine(),out input);
                if (!isDecimal) Console.WriteLine("Debe introducir un número decimal.");
            } while (!isDecimal && (input < min || input > max));
            return input;
        }
    }
}
