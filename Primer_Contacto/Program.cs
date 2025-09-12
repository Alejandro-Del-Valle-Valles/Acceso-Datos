namespace Primer_Contacto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers = {
                {1, 2, 3},
                {4, 5, 6}
            };

            byte[][] numbersByte = new byte[2][]
            {
                new byte[] { 1, 2, 3 },
                new byte[] { 4, 5, 6 }
            };

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
