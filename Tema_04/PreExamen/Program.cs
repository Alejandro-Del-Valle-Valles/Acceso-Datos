using PreExamen.Ejercicios;

namespace PreExamen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Ejercicio02App.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }
    }
}
