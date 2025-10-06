using Ejercicios01hasta06App.Model;
using Ejercicios01hasta06App.Service;

namespace Ejercicios01hasta06App.Exercises
{
    internal static class Ejercicio01App
    {

        private static ProductsJsonFileRepository pjfr = new ProductsJsonFileRepository();
        public static void start()
        {
            pjfr.FindAll()?.ForEach(p => Console.WriteLine(p));
            Product product = new Product(5, "Ratón", 15.95f, 4, false);
            pjfr.Save(product);
        }
    }
}
