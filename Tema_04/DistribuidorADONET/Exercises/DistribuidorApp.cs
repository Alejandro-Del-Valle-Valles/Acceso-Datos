using DistribuidorADONET.Interfaces;
using DistribuidorADONET.Model;
using DistribuidorADONET.Service;
using DistribuidorADONET.DAO;

namespace DistribuidorADONET.Exercises
{
    internal static class DistribuidorApp
    {
        private static readonly IGenericService<Article>
            ArticlesDbManager = new ArticleService(new ArticlePostgreDao());
        private static readonly IGenericService<Manufacturer> ManufacturersDbManager =
            new ManufacturerService(new ManufacturerPostgreDao());

        public static void Start()
        {
            Console.WriteLine("Por implementar.");
        }
    }
}
