using DistribuidorADONET.Exercises;

namespace DistribuidorADONET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DistribuidorApp.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
            }

        }
    }
}
