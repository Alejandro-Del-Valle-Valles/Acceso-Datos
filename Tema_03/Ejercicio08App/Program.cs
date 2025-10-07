using Ejercicio08App.Repositories;
using Ejercicio08App.services;

namespace Ejercicio08App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(OrderResumService.GetStats());
        }
    }
}
